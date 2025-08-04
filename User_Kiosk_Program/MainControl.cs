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
                string bannerUrl = DatabaseManager.Instance.GetWebBannerImageUrl("select_stage_banner");
                if (!string.IsNullOrEmpty(bannerUrl))
                {
                    var imageStream = await httpClient.GetStreamAsync(bannerUrl);
                    // 원본 배너 이미지를 그대로 전달합니다.
                    Image bannerImage = Image.FromStream(imageStream);
                    pageSelectStage.SetBannerImage(bannerImage);
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
                    // 원본 이미지를 그대로 리스트에 추가합니다.
                    images.Add(Image.FromStream(imageStream));
                }
                catch (Exception ex) { Console.WriteLine($"광고 이미지 로딩 실패 (URL: {url}): {ex.Message}"); }
            }
            return images;
        }

        
    }
}
