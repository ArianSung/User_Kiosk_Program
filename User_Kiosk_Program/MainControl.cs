using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private Page_Payment pagePayment;
        private Image appLogo;
        private Color mainThemeColor;
        private Color panelBackgroundColor;
        private Pop_Use_Point pointsPopup;

        private Pop_Option_Drink optionPopup;

        private List<Category> preloadedCategories;
        private Dictionary<int, List<Product>> preloadedProducts;
        private List<Image> preloadedAdImages = new List<Image>();

        private long currentOrderId = -1;
        private OrderType currentOrderType;
        private System.Windows.Forms.Timer? inactivityTimer;


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
            pagePayment = new Page_Payment();

            this.Controls.Add(pageDefault);
            this.Controls.Add(pageSelectStage);
            this.Controls.Add(pageMain);
            this.Controls.Add(pagePayment);


            InitializePopup();
            // 팝업 컨트롤은 다른 페이지들과 달리 Dock.Fill을 사용하지 않으므로,
            // Controls 컬렉션에 나중에 추가하는 것이 좋습니다.
            this.Controls.Add(optionPopup);
            this.Controls.Add(pointsPopup);

            foreach (Control page in this.Controls)
    {
        // 페이지 컨트롤들만 Dock.Fill을 적용하고, 팝업들은 제외합니다.
        if (page is Page_Default || page is Page_Select_Stage || page is Page_Main || page is Page_Payment)
        {
            page.Dock = DockStyle.Fill;
            page.Visible = false;
        }
    }

            // 이벤트 구독
            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;
            pageSelectStage.OrderTypeSelected += OnOrderTypeSelected;
            pageMain.ProductSelected += OnProductSelected;
            pageMain.ProceedToPaymentClicked += OnProceedToPaymentClicked; // OnProceedToPaymentClicked로 수정
            pageMain.HomeButtonClicked += (s, e) => ShowPage(pageSelectStage);
            pagePayment.PointPaymentClicked += OnPayment_PointPaymentClicked;
            pagePayment.BackButtonClicked += OnPayment_BackButtonClicked;
            pageSelectStage.UserActivity += PageSelectStage_UserActivity;

            optionPopup.ConfirmClicked += OptionPopup_ConfirmClicked;
            optionPopup.CancelClicked += (s, e) => HideOptionPopup();
            pointsPopup.ApplyClicked += OnPointsApplied;
            pointsPopup.CancelClicked += (s, e) => HidePointsPopup();

            await Task.WhenAll(LoadThemeColorsAsync(), LoadSharedResourcesAsync(), LoadDefaultPageData(), LoadMainPageData());

            ApplyLogosToPages();
            ApplyThemeToPages();
            pageMain.SetInitialData(preloadedCategories, preloadedProducts);
            pageDefault.StartAds(preloadedAdImages); // 올바른 변수 이름으로 수정

            ShowPage(pageDefault);
            this.Cursor = Cursors.Default;
        }

        private void PageSelectStage_UserActivity(object? sender, EventArgs e)
        {
            // 타이머가 존재할 경우에만 리셋합니다.
            if (inactivityTimer != null)
            {
                inactivityTimer.Stop();
                inactivityTimer.Start();
            }
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            // 타이머의 역할이 끝났으므로 첫 페이지로 돌아갑니다.
            // ShowPage 메서드가 타이머를 자동으로 정리해 줄 것입니다.
            ShowPage(pageDefault);
        }

        private void OnPayment_BackButtonClicked(object? sender, CartEventArgs e)
        {
            pageMain.UpdateShoppingCart(e.ShoppingCart);
            ShowPage(pageMain);
        }

        private void OnPayment_PointPaymentClicked(object? sender, decimal orderAmount)
        {
            pointsPopup.Initialize(orderAmount);
            ShowPointsPopup();
        }

        private void OnPointsApplied(object? sender, PointUsageEventArgs e)
        {
            // Page_Payment에 포인트를 적용하도록 지시
            pagePayment.ApplyPoints(e.PointsToUse);
            // 팝업 닫기
            HidePointsPopup();
        }

        private void ShowPointsPopup()
        {
            pointsPopup.BringToFront();
            pointsPopup.Visible = true;
        }

        private void HidePointsPopup()
        {
            pointsPopup.Visible = false;
        }

        private async Task LoadThemeColorsAsync()
        {
            mainThemeColor = await Task.Run(() => DatabaseManager.Instance.GetSystemColor("main_theme_color"));
            panelBackgroundColor = await Task.Run(() => DatabaseManager.Instance.GetSystemColor("panel_background_color"));
        }
        private void ApplyThemeToPages()
        {
            // 각 페이지에 만들어 둘 SetTheme 메서드를 호출
            pageMain.SetTheme(mainThemeColor, panelBackgroundColor);
            pagePayment.SetTheme(mainThemeColor, panelBackgroundColor);
            pageSelectStage.SetTheme(mainThemeColor, panelBackgroundColor);
            //pageSelectStage.SetTheme(mainThemeColor, panelBackgroundColor);
            // ... 다른 페이지들도 동일하게 추가 ...
        }


        private async void OnProductSelected(object sender, ProductSelectedEventArgs e)
        {
            var product = e.SelectedProduct;
            product.OptionGroups = await Task.Run(() => DatabaseManager.Instance.GetOptionsForProduct(product.ProductId));
            ShowOptionPopup(product);
        }

        private void InitializePopup()
        {
            // 기존 옵션 팝업 생성
            optionPopup = new Pop_Option_Drink { Visible = false, Size = new Size(600, 720), Location = new Point((this.Width - 600) / 2, (this.Height - 720) / 2), Anchor = AnchorStyles.None };
            this.Controls.Add(optionPopup);

            // 포인트 팝업 생성 로직 추가
            pointsPopup = new Pop_Use_Point { Visible = false, Size = new Size(600, 720), Location = new Point((this.Width - 600) / 2, (this.Height - 850) / 2), Anchor = AnchorStyles.None };
            this.Controls.Add(pointsPopup);
        }

        private void OptionPopup_ConfirmClicked(object sender, OrderItemEventArgs e)
        {
            pageMain.AddItemToCart(e.Item);
            HideOptionPopup();
        }

        private void ShowOptionPopup(Product product)
        {
            optionPopup.SetProduct(product);
            optionPopup.BringToFront();
            optionPopup.Visible = true;
        }

        private void HideOptionPopup()
        {
            optionPopup.Visible = false;
        }

        private async Task LoadDefaultPageData()
        {
            List<string> adUrls = await Task.Run(() => DatabaseManager.Instance.GetAdImageUrls());
            // preloadedAdImages 리스트에 이미지 저장
            preloadedAdImages = new List<Image>();
            foreach (var url in adUrls)
            {
                var imageStream = await httpClient.GetStreamAsync(url);
                var originalImage = Image.FromStream(imageStream);
                preloadedAdImages.Add(ImageHelper.ResizeImage(originalImage, pageDefault.Size));
                originalImage.Dispose();
            }
        }

        private async Task LoadMainPageData()
        {
            preloadedCategories = await Task.Run(() => DatabaseManager.Instance.GetCategories());
            preloadedProducts = new Dictionary<int, List<Product>>();

            foreach (var category in preloadedCategories)
            {
                var products = await Task.Run(() => DatabaseManager.Instance.GetProductsByCategory(category.CategoryId));
                preloadedProducts[category.CategoryId] = products;
            }

            var imageLoadTasks = new List<Task>();
            foreach (var product in preloadedProducts.Values.SelectMany(p => p))
            {
                if (!string.IsNullOrEmpty(product.ProductImageUrl))
                {
                    imageLoadTasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            var imageStream = await httpClient.GetStreamAsync(product.ProductImageUrl);
                            var originalImage = Image.FromStream(imageStream);
                            product.ProductImage = ImageHelper.ResizeImage(originalImage, new Size(125, 140));
                            originalImage.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Image Error (URL: {product.ProductImageUrl}): {ex.Message}");
                            product.ProductImage = null;
                        }
                    }));
                }
            }
            await Task.WhenAll(imageLoadTasks);
        }

        private async Task LoadSharedResourcesAsync()
        {
            appLogo = await Task.Run(() => DatabaseManager.Instance.GetSystemImage("main_logo"));
        }

        private void ApplyLogosToPages()
        {
            //pageDefault.SetLogo(appLogo);
            //pageSelectStage.SetLogo(appLogo);
            pageMain.SetLogo(appLogo);
            pagePayment.SetLogo(appLogo);
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
            // 1. 만약 이전에 실행되던 타이머가 있다면, 확실하게 멈추고 메모리에서 제거합니다.
            if (inactivityTimer != null)
            {
                inactivityTimer.Stop();
                inactivityTimer.Dispose(); // 타이머 리소스 해제
                inactivityTimer = null;
            }

            // 2. 만약 새로 보여줄 페이지가 Page_Select_Stage라면, 타이머를 새로 생성하고 시작합니다.
            if (pageToShow == pageSelectStage)
            {
                inactivityTimer = new System.Windows.Forms.Timer();
                inactivityTimer.Interval = 30000; // 30초
                inactivityTimer.Tick += InactivityTimer_Tick;
                inactivityTimer.Start();
            }

            // 페이지를 보여주는 로직 (기존과 동일)
            foreach (Control page in this.Controls)
            {
                if (page is UserControl && page != optionPopup && page != pointsPopup)
                    page.Visible = (page == pageToShow);
            }
        }

        // ▼▼▼▼▼ 참조 오류가 발생한 메서드 이름을 OnProceedToPaymentClicked -> PageMain_ProceedToPaymentClicked로 수정 ▼▼▼▼▼
        private async void OnProceedToPaymentClicked(object sender, CartEventArgs e)
        {
            // 결제 페이지에 장바구니 데이터를 채우고
            await pagePayment.PopulateCart(e.ShoppingCart);
            // 결제 페이지를 화면에 보여줌
            ShowPage(pagePayment);
        }
    }
}