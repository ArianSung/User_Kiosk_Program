using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Default : UserControl
    {
        // 광고 전환 관련
        private List<string> adImageUrls;
        private int currentAdIndex = -1;
        private readonly HttpClient httpClient = new HttpClient();

        // 이미지 및 페이드 효과 관련
        private Image currentImage;
        private Image nextImage;
        private readonly System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        private int fadeStep = 0;
        private const int FADE_MAX_STEPS = 20;

        public Page_Default()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // 화면 깜빡임 방지를 위한 더블 버퍼링 활성화
            this.Load += Page_Default_Load;

            fadeTimer.Interval = 25;
            fadeTimer.Tick += FadeTimer_Tick;
        }

        private async void Page_Default_Load(object sender, EventArgs e)
        {
            await InitializeAds();
        }

        private async Task InitializeAds()
        {
            adImageUrls = DatabaseManager.Instance.GetAdImageUrls();

            if (adImageUrls != null && adImageUrls.Count > 0)
            {
                currentAdIndex = 0;
                try
                {
                    Image originalImage = await LoadImageAsync(adImageUrls[currentAdIndex]);
                    currentImage = ResizeImage(originalImage, pb_Ad.Size); // 로드 후 바로 리사이즈
                    originalImage.Dispose();

                    pb_Ad.Image = currentImage;
                    adChangeTimer.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Initial image load failed: {ex.Message}");
                }
            }
        }

        private async void adChangeTimer_Tick(object sender, EventArgs e)
        {
            if (fadeTimer.Enabled) return;

            currentAdIndex = (currentAdIndex + 1) % adImageUrls.Count;

            try
            {
                Image originalImage = await LoadImageAsync(adImageUrls[currentAdIndex]);
                nextImage = ResizeImage(originalImage, pb_Ad.Size); // 다음 이미지도 미리 리사이즈
                originalImage.Dispose(); // 원본 이미지는 메모리에서 해제

                fadeStep = 0;
                fadeTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Next image load failed: {ex.Message}");
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            fadeStep++;
            float opacity = (float)fadeStep / FADE_MAX_STEPS;

            pb_Ad.Image = BlendImages(currentImage, nextImage, opacity);

            if (fadeStep >= FADE_MAX_STEPS)
            {
                fadeTimer.Stop();
                currentImage.Dispose(); // 이전 이미지 리소스 해제
                currentImage = nextImage;
                pb_Ad.Image = currentImage;
                nextImage = null;
            }
        }

        private async Task<Image> LoadImageAsync(string url)
        {
            var imageStream = await httpClient.GetStreamAsync(url);
            return Image.FromStream(imageStream);
        }

        private Bitmap ResizeImage(Image sourceImage, Size targetSize)
        {
            // 최종 결과물이 될 비트맵을 PictureBox 크기로 생성
            var resultBitmap = new Bitmap(targetSize.Width, targetSize.Height, PixelFormat.Format32bppArgb);
            resultBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var g = Graphics.FromImage(resultBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic; // 이미지 품질 설정

                // 'Zoom' 로직 직접 구현
                float sourceRatio = (float)sourceImage.Width / sourceImage.Height;
                float targetRatio = (float)targetSize.Width / targetSize.Height;
                float scaleWidth, scaleHeight;

                if (sourceRatio > targetRatio) // 원본 이미지가 더 넓으면 너비에 맞춤
                {
                    scaleWidth = targetSize.Width;
                    scaleHeight = targetSize.Width / sourceRatio;
                }
                else // 원본 이미지가 더 높으면 높이에 맞춤
                {
                    scaleHeight = targetSize.Height;
                    scaleWidth = targetSize.Height * sourceRatio;
                }

                // 중앙 정렬을 위한 위치 계산
                float posX = (targetSize.Width - scaleWidth) / 2;
                float posY = (targetSize.Height - scaleHeight) / 2;

                // 계산된 크기와 위치로 새 비트맵에 원본 이미지를 그림
                g.DrawImage(sourceImage, posX, posY, scaleWidth, scaleHeight);
            }

            return resultBitmap;
        }

        private Bitmap BlendImages(Image oldImage, Image newImage, float opacity)
        {
            // 이 메서드는 이제 항상 동일한 크기의 이미지를 받으므로 수정할 필요가 없습니다.
            // (이하 이전과 동일한 코드)
            if (oldImage == null) return new Bitmap(newImage);
            if (newImage == null) return new Bitmap(oldImage);

            if (opacity > 1.0f) opacity = 1.0f;
            else if (opacity < 0.0f) opacity = 0.0f;

            var blendedBitmap = new Bitmap(oldImage.Width, oldImage.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(blendedBitmap))
            {
                g.DrawImage(oldImage, new Rectangle(0, 0, oldImage.Width, oldImage.Height));
                ColorMatrix matrix = new ColorMatrix { Matrix33 = opacity };
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(newImage, new Rectangle(0, 0, newImage.Width, newImage.Height),
                            0, 0, newImage.Width, newImage.Height, GraphicsUnit.Pixel, attributes);
            }
            return blendedBitmap;
        }
    }
}
