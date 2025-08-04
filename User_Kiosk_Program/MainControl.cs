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

        // 팝업 관련 컨트롤들을 MainControl이 직접 관리합니다.
        private Panel popupOverlay;
        private Pop_Option_Drink optionPopup;

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

            // 모든 페이지 인스턴스를 미리 생성
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

            // 팝업 컨트롤들을 여기서 초기화
            InitializePopup();

            // 페이지들의 이벤트 구독
            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;
            pageSelectStage.OrderTypeSelected += OnOrderTypeSelected;
            pageMain.ProductSelected += OnProductSelected; // Page_Main의 신호 구독

            // 첫 페이지 로딩 및 표시
            await LoadDefaultPageData();
            ShowPage(pageDefault);
            this.Cursor = Cursors.Default;
        }

        // Page_Main에서 상품이 클릭되었다는 신호를 받았을 때 실행될 메서드
        private async void OnProductSelected(object sender, ProductSelectedEventArgs e)
        {
            var product = e.SelectedProduct;

            // DB에서 최신 옵션 정보를 가져옵니다.
            product.OptionGroups = await Task.Run(() => DatabaseManager.Instance.GetOptionsForProduct(product.ProductId));

            // MainControl이 직접 팝업을 띄웁니다.
            ShowOptionPopup(product);
        }

        // 팝업 관리 메서드들
        private void InitializePopup()
        {
            popupOverlay = new Panel { BackColor = Color.FromArgb(128, Color.Black), Dock = DockStyle.Fill, Visible = false };
            this.Controls.Add(popupOverlay);

            optionPopup = new Pop_Option_Drink { Visible = false, Size = new Size(600, 720), Location = new Point((this.Width - 600) / 2, (this.Height - 720) / 2), Anchor = AnchorStyles.None };
            this.Controls.Add(optionPopup);

            optionPopup.ConfirmClicked += (s, e) => HideOptionPopup();
            optionPopup.CancelClicked += (s, e) => HideOptionPopup();
        }

        private void ShowOptionPopup(Product product)
        {
            optionPopup.SetProduct(product);
            popupOverlay.BringToFront();
            optionPopup.BringToFront();
            popupOverlay.Visible = true;
            optionPopup.Visible = true;
        }

        private void HideOptionPopup()
        {
            popupOverlay.Visible = false;
            optionPopup.Visible = false;
        }

        // 페이지 전환 및 데이터 로딩 로직
        private async Task LoadDefaultPageData()
        {
            List<string> adUrls = await Task.Run(() => DatabaseManager.Instance.GetAdImageUrls());
            List<Image> adImages = new List<Image>();
            foreach (var url in adUrls)
            {
                var imageStream = await httpClient.GetStreamAsync(url);
                var originalImage = Image.FromStream(imageStream);
                adImages.Add(ImageHelper.ResizeImage(originalImage, pageDefault.Size));
                originalImage.Dispose();
            }
            pageDefault.StartAds(adImages);
        }

        private async void OnDefaultPageScreenClicked(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string bannerUrl = await Task.Run(() => DatabaseManager.Instance.GetWebBannerImageUrl("select_stage_banner"));
            if (!string.IsNullOrEmpty(bannerUrl))
            {
                var imageStream = await httpClient.GetStreamAsync(bannerUrl);
                var originalImage = Image.FromStream(imageStream);
                pageSelectStage.SetBannerImage(ImageHelper.ResizeImage(originalImage, pageSelectStage.Size));
                originalImage.Dispose();
            }
            ShowPage(pageSelectStage);
            this.Cursor = Cursors.Default;
        }

        private async void OnOrderTypeSelected(object sender, OrderTypeSelectedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            long newOrderId = await Task.Run(() => DatabaseManager.Instance.CreateNewOrder(e.SelectedOrderType));

            if (newOrderId != -1)
            {
                this.currentOrderId = newOrderId;
                this.currentOrderType = e.SelectedOrderType;
                ShowMainPage(this.currentOrderType, this.currentOrderId);
            }
            else
            {
                MessageBox.Show("주문 생성에 실패했습니다.");
            }
            this.Cursor = Cursors.Default;
        }

        private void ShowMainPage(OrderType orderType, long orderId)
        {
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
    }
}