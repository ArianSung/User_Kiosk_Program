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
        // 이벤트 핸들러
        public event EventHandler ScreenClicked;

        // 광고 전환 관련
        private List<Image> adImages;
        private int currentAdIndex = -1;

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

            this.Click += OnScreenClicked;
            pb_Ad.Click += OnScreenClicked;
            

            fadeTimer.Interval = 25;
            fadeTimer.Tick += FadeTimer_Tick;
        }

        // MainControl이 호출할 메서드
        public void StartAds(List<Image> originalImages)
        {
            if (originalImages == null || originalImages.Count == 0)
            {
                pb_Ad.BackColor = Color.DimGray;
                return;
            }

            // 새 리스트를 만들어 리사이즈된 이미지를 저장
            adImages = new List<Image>();
            foreach (var img in originalImages)
            {
                // ImageHelper를 사용하여 자신의 PictureBox 크기에 맞게 리사이즈
                adImages.Add(ImageHelper.ResizeImage(img, pb_Ad.Size));
                img.Dispose(); // 원본 이미지 리소스 해제
            }

            if (adImages.Count > 0)
            {
                currentAdIndex = 0;
                currentImage = adImages[currentAdIndex];
                pb_Ad.Image = currentImage;
                adChangeTimer.Start();
            }
        }


        private void OnScreenClicked(object? sender, EventArgs e)
        {
            // ScreenClicked 이벤트를 구독한 대상이 있으면 이벤트를 발생시킴
            ScreenClicked?.Invoke(this, EventArgs.Empty);
        }


        private void adChangeTimer_Tick(object sender, EventArgs e)
        {
            if (fadeTimer.Enabled || adImages.Count < 2) return;

            currentAdIndex = (currentAdIndex + 1) % adImages.Count;
            nextImage = adImages[currentAdIndex];

            fadeStep = 0;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            fadeStep++;
            float opacity = (float)fadeStep / FADE_MAX_STEPS;
            pb_Ad.Image = BlendImages(currentImage, nextImage, opacity);
            if (fadeStep >= FADE_MAX_STEPS)
            {
                fadeTimer.Stop();
                // 중요: adImages 리스트의 원본 이미지는 MainControl이 관리하므로 Dispose하면 안 됩니다.
                // currentImage는 이제 다음 nextImage를 가리키게 합니다.
                currentImage = nextImage;
                pb_Ad.Image = currentImage;
                nextImage = null;
            }
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
