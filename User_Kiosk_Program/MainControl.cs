using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class MainControl : UserControl
    {
        private readonly HttpClient httpClient = new HttpClient();

        private Page_Default pageDefault;
        private Page_Select_Stage pageSelectStage;
        private Page_Main pageMain;

        // 현재 주문 정보를 저장할 변수
        private long currentOrderId = -1;
        private OrderType currentOrderType;

        public MainControl()
        {
            InitializeComponent();
            this.Load += MainControl_Load;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private async void MainControl_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            pageDefault = new Page_Default();
            pageSelectStage = new Page_Select_Stage();
            pageMain = new Page_Main();

            this.Controls.Add(pageDefault);
            this.Controls.Add(pageSelectStage);
            this.Controls.Add(pageMain);

            foreach (Control page in this.Controls)
            {
                page.Dock = DockStyle.Fill;
                page.Visible = false;
            }

            try
            {
                List<Image> adImages = await LoadAdImagesAsync();
                pageDefault.StartAds(adImages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"초기 데이터 로딩 실패: {ex.Message}");
            }

            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;
            pageSelectStage.OrderTypeSelected += OnOrderTypeSelected;

            ShowPage(pageDefault);
            this.Cursor = Cursors.Default;
        }

        private async void OnDefaultPageScreenClicked(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string bannerUrl = DatabaseManager.Instance.GetWebBannerImageUrl("select_stage_banner");
                if (!string.IsNullOrEmpty(bannerUrl))
                {
                    var imageStream = await httpClient.GetStreamAsync(bannerUrl);
                    Image bannerImage = Image.FromStream(imageStream);
                    pageSelectStage.SetBannerImage(bannerImage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"배너 이미지 미리 로딩 실패: {ex.Message}");
                pageSelectStage.SetBannerImage(null);
            }
            ShowPage(pageSelectStage);
            this.Cursor = Cursors.Default;
        }

        private async void OnOrderTypeSelected(object sender, OrderTypeSelectedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // DB에 주문 생성을 요청하고 새로 생성된 order_id를 받아옵니다.
            long newOrderId = await Task.Run(() => DatabaseManager.Instance.CreateNewOrder(e.SelectedOrderType));

            if (newOrderId != -1)
            {
                // 성공 시 현재 주문 정보 저장
                this.currentOrderId = newOrderId;
                this.currentOrderType = e.SelectedOrderType;

                Console.WriteLine($"새 주문 생성됨. ID: {this.currentOrderId}, 유형: {this.currentOrderType}");

                // 다음 페이지로 주문 유형과 'orderId'를 함께 전달
                ShowMainPage(this.currentOrderType, this.currentOrderId);
            }
            else
            {
                MessageBox.Show("주문 생성에 실패했습니다. 다시 시도해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void ShowMainPage(OrderType orderType, long orderId)
        {
            // 두 개의 인수를 모두 전달
            pageMain.InitializePage(orderType, orderId);
            ShowPage(pageMain);
        }

        private void ShowPage(Control pageToShow)
        {
            foreach (Control page in this.Controls)
            {
                page.Visible = (page == pageToShow);
            }
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
                    images.Add(ImageHelper.ResizeImage(originalImage, pageDefault.Size));
                    originalImage.Dispose();
                }
                catch (Exception ex) { Console.WriteLine($"광고 이미지 로딩 실패 (URL: {url}): {ex.Message}"); }
            }
            return images;
        }
    }
}