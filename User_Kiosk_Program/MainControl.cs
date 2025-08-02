using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class MainControl : UserControl
    {

        private readonly HttpClient httpClient = new HttpClient();

        // 페이지 설계도 생성
        private Page_Default pageDefault;
        private Page_Select_Stage pageSelectStage;


        public MainControl()
        {
            InitializeComponent();
            this.Load += MainControl_Load;
        }

        // 깜빡임 해결
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void MainControl_Load(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // 모든 페이지 인스턴스를 미리 생성합니다.
            pageDefault = new Page_Default();
            pageSelectStage = new Page_Select_Stage();

            // 모든 페이지를 Controls에 추가합니다.
            this.Controls.Add(pageDefault);
            this.Controls.Add(pageSelectStage);

            // 모든 페이지의 공통 속성을 설정합니다.
            foreach (Control page in this.Controls)
            {
                page.Dock = DockStyle.Fill;
                page.Visible = false; // 우선 모두 숨깁니다.
            }

            // 첫 페이지에 필요한 데이터를 로드합니다.
            try
            {
                List<Image> adImages = await LoadAdImagesAsync();
                pageDefault.StartAds(adImages); // 데이터를 전달합니다.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"초기 데이터 로딩 실패: {ex.Message}");
            }

            // 첫 페이지만 화면에 보여줍니다.
            pageDefault.Visible = true;
            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;

            this.Cursor = Cursors.Default;
        }

        // 페이지를 보여주는 공통 메서드
        private void ShowPage(Control pageToShow)
        {
            // 보여주고자 하는 페이지만 남기고 모두 숨깁니다.
            foreach (Control page in this.Controls)
            {
                page.Visible = (page == pageToShow);
            }
        }

        private async void OnDefaultPageScreenClicked(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // 다음 페이지에 필요한 데이터를 미리 로드합니다.
                string bannerUrl = DatabaseManager.Instance.GetWebBannerImageUrl("select_stage_banner");
                if (!string.IsNullOrEmpty(bannerUrl))
                {
                    var imageStream = await httpClient.GetStreamAsync(bannerUrl);
                    var originalImage = Image.FromStream(imageStream);
                    Image bannerImage = ResizeImage(originalImage, this.Size);

                    // 미리 생성해 둔 인스턴스에 데이터를 전달합니다.
                    pageSelectStage.SetBannerImage(bannerImage);
                    originalImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"배너 이미지 미리 로딩 실패: {ex.Message}");
                pageSelectStage.SetBannerImage(null); // 실패 시 null 전달
            }

            // 페이지 전환
            ShowPage(pageSelectStage);
            this.Cursor = Cursors.Default;
        }

        private async Task<List<Image>> LoadAdImagesAsync()
        {
            var images = new List<Image>();
            List<string> urls = DatabaseManager.Instance.GetAdImageUrls();
            foreach (var url in urls)
            {
                try
                {
                    var imageStream = await httpClient.GetStreamAsync(url);
                    var originalImage = Image.FromStream(imageStream);
                    images.Add(ResizeImage(originalImage, this.Size));
                    originalImage.Dispose();
                }
                catch (Exception ex) { Console.WriteLine($"광고 이미지 로딩 실패 (URL: {url}): {ex.Message}"); }
            }
            return images;
        }

        // 리사이즈 메서드
        private Bitmap ResizeImage(Image sourceImage, Size targetSize)
        {
            var resultBitmap = new Bitmap(targetSize.Width, targetSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            resultBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            using (var g = Graphics.FromImage(resultBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                float sourceRatio = (float)sourceImage.Width / sourceImage.Height;
                float targetRatio = (float)targetSize.Width / targetSize.Height;
                float scaleWidth, scaleHeight;
                if (sourceRatio > targetRatio) { scaleWidth = targetSize.Width; scaleHeight = targetSize.Width / sourceRatio; }
                else { scaleHeight = targetSize.Height; scaleWidth = targetSize.Height * sourceRatio; }
                float posX = (targetSize.Width - scaleWidth) / 2;
                float posY = (targetSize.Height - scaleHeight) / 2;
                g.DrawImage(sourceImage, posX, posY, scaleWidth, scaleHeight);
            }
            return resultBitmap;
        }
    }
}
