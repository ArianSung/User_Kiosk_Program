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

        private Pop_Option_Drink optionPopup;
        private Pop_Use_Point pointsPopup;
        private Pop_Use_Card cardPopup;
        private Pop_Store_Point storePointPopup;
        private Pop_New_Member newMemberPopup;

        private List<Category> preloadedCategories;
        private Dictionary<int, List<Product>> preloadedProducts;
        private List<Image> preloadedAdImages = new List<Image>();

        private long currentOrderId = -1;
        private OrderType currentOrderType;
        private System.Windows.Forms.Timer? inactivityTimer;

        private decimal currentFinalAmount;
        private int currentPointsUsed;
        private Member currentPointUser;

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

            InitializePopup();

            this.Controls.Add(pageDefault);
            this.Controls.Add(pageSelectStage);
            this.Controls.Add(pageMain);
            this.Controls.Add(pagePayment);
            this.Controls.Add(optionPopup);
            this.Controls.Add(pointsPopup);
            this.Controls.Add(cardPopup);
            this.Controls.Add(storePointPopup);
            this.Controls.Add(newMemberPopup);

            foreach (Control page in this.Controls)
            {
                if (page is UserControl && !(page is Pop_Option_Drink || page is Pop_Use_Point || page is Pop_Use_Card || page is Pop_Store_Point || page is Pop_New_Member))
                {
                    page.Dock = DockStyle.Fill;
                    page.Visible = false;
                }
            }

            // 이벤트 구독
            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;
            pageSelectStage.OrderTypeSelected += OnOrderTypeSelected;
            pageMain.ProductSelected += OnProductSelected;
            pageMain.ProceedToPaymentClicked += OnProceedToPaymentClicked;
            pageMain.HomeButtonClicked += (s, e) => ShowPage(pageSelectStage);
            pagePayment.PointPaymentClicked += OnPointPaymentClicked;
            pagePayment.BackButtonClicked += OnPaymentBackButtonClicked;
            pagePayment.CreditCardPaymentClicked += OnCreditCardPaymentClicked;
            pageSelectStage.UserActivity += OnPageSelectStageActivity;

            optionPopup.ConfirmClicked += OptionPopup_ConfirmClicked;
            optionPopup.CancelClicked += (s, e) => HideOptionPopup();
            pointsPopup.ApplyClicked += OnPointsApplied;
            pointsPopup.CancelClicked += (s, e) => HidePointsPopup();
            cardPopup.PaymentConfirmed += OnCardPaymentConfirmed;
            cardPopup.CancelClicked += (s, e) => HideCardPopup();
            storePointPopup.ConfirmClicked += OnStorePointConfirmClicked;
            storePointPopup.SkipClicked += (s, e) => ResetToDefaultPage();
            newMemberPopup.ConfirmClicked += OnNewMemberConfirmClicked;

            await Task.WhenAll(LoadThemeColorsAsync(), LoadSharedResourcesAsync(), LoadDefaultPageData(), LoadMainPageData());

            ApplyLogosToPages();
            ApplyThemeToPages();
            pageMain.SetInitialData(preloadedCategories, preloadedProducts);
            pageDefault.StartAds(preloadedAdImages);

            ShowPage(pageDefault);
            this.Cursor = Cursors.Default;
        }

        private void OnCreditCardPaymentClicked(object sender, CreditCardEventArgs e)
        {
            this.currentFinalAmount = e.FinalAmount;
            this.currentPointsUsed = e.PointsUsed;
            this.currentPointUser = e.PointUser;
            ShowCardPopup();
        }

        // ▼▼▼▼▼ 여기가 수정된 핵심 부분입니다 ▼▼▼▼▼
        private void OnCardPaymentConfirmed(object sender, EventArgs e)
        {
            HideCardPopup();

            // 1. 포인트 사용 내역이 있으면 (currentPointsUsed > 0), DB에 차감 적용
            if (currentPointUser != null && currentPointsUsed > 0)
            {
                // UpdateMemberPoints는 int형 포인트를 받으므로 -currentPointsUsed를 전달하여 차감
                DatabaseManager.Instance.UpdateMemberPoints(currentPointUser.PhoneNumber, -currentPointsUsed);
            }

            // 2. 포인트 적립 팝업 띄우기
            ShowStorePointPopup();
        }
        // ▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

        private void OnStorePointConfirmClicked(object sender, string phoneNumber)
        {
            HideStorePointPopup();

            var member = DatabaseManager.Instance.GetMemberByPhoneNumber(phoneNumber);
            int pointsToStore = (int)(currentFinalAmount * 0.03m);

            if (member != null)
            {
                DatabaseManager.Instance.UpdateMemberPoints(phoneNumber, pointsToStore);
                MessageBox.Show($"{pointsToStore:N0}P가 적립되었습니다.");
                ResetToDefaultPage();
            }
            else
            {
                DatabaseManager.Instance.CreateNewMember(phoneNumber, pointsToStore);
                ShowNewMemberPopup();
            }
        }

        private void OnNewMemberConfirmClicked(object sender, EventArgs e)
        {
            HideNewMemberPopup();
            ResetToDefaultPage();
        }

        private void ResetToDefaultPage()
        {
            pageMain.ClearCart();
            pagePayment.SetPointUser(null);
            pagePayment.ApplyPoints(0);
            ShowPage(pageDefault);
        }

        private void ShowCardPopup() { cardPopup.BringToFront(); cardPopup.Visible = true; }
        private void HideCardPopup() { cardPopup.Visible = false; }
        private void ShowStorePointPopup() { storePointPopup.Clear(); storePointPopup.BringToFront(); storePointPopup.Visible = true; }
        private void HideStorePointPopup() { storePointPopup.Visible = false; }
        private void ShowNewMemberPopup() { newMemberPopup.BringToFront(); newMemberPopup.Visible = true; }
        private void HideNewMemberPopup() { newMemberPopup.Visible = false; }

        private void OnPageSelectStageActivity(object sender, EventArgs e)
        {
            if (inactivityTimer != null)
            {
                inactivityTimer.Stop();
                inactivityTimer.Start();
            }
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            ShowPage(pageDefault);
        }

        private void OnPaymentBackButtonClicked(object sender, CartEventArgs e)
        {
            pageMain.UpdateShoppingCart(e.ShoppingCart);
            ShowPage(pageMain);
        }

        private void OnPointPaymentClicked(object sender, PointPaymentEventArgs e)
        {
            pagePayment.SetPointUser(e.PointUser);
            pointsPopup.Initialize(e.OrderAmount);
            ShowPointsPopup();
        }

        private void OnPointsApplied(object sender, PointUsageEventArgs e)
        {
            this.currentPointUser = e.Member;
            pagePayment.SetPointUser(this.currentPointUser);
            pagePayment.ApplyPoints(e.PointsToUse);
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
            pageMain.SetTheme(mainThemeColor, panelBackgroundColor);
            pagePayment.SetTheme(mainThemeColor, panelBackgroundColor);
            pageSelectStage.SetTheme(mainThemeColor, panelBackgroundColor);
        }

        private async void OnProductSelected(object sender, ProductSelectedEventArgs e)
        {
            var product = e.SelectedProduct;
            product.OptionGroups = await Task.Run(() => DatabaseManager.Instance.GetOptionsForProduct(product.ProductId));
            ShowOptionPopup(product);
        }

        private void InitializePopup()
        {
            optionPopup = new Pop_Option_Drink { Visible = false, Size = new Size(600, 720), Location = new Point((this.Width - 600) / 2, (this.Height - 720) / 2), Anchor = AnchorStyles.None };
            pointsPopup = new Pop_Use_Point { Visible = false, Size = new Size(600, 850), Location = new Point((this.Width - 600) / 2, (this.Height - 850) / 2), Anchor = AnchorStyles.None };
            cardPopup = new Pop_Use_Card { Visible = false, Size = new Size(400, 250), Location = new Point((this.Width - 400) / 2, (this.Height - 250) / 2), Anchor = AnchorStyles.None };
            storePointPopup = new Pop_Store_Point { Visible = false, Size = new Size(600, 700), Location = new Point((this.Width - 600) / 2, (this.Height - 700) / 2), Anchor = AnchorStyles.None };
            newMemberPopup = new Pop_New_Member { Visible = false, Size = new Size(400, 250), Location = new Point((this.Width - 400) / 2, (this.Height - 200) / 2), Anchor = AnchorStyles.None };
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
                    imageLoadTasks.Add(Task.Run(async () => {
                        try
                        {
                            var imageStream = await httpClient.GetStreamAsync(product.ProductImageUrl);
                            var originalImage = Image.FromStream(imageStream);
                            product.ProductImage = ImageHelper.ResizeImage(originalImage, new Size(125, 140));
                            originalImage.Dispose();
                        }
                        catch (Exception ex) { Console.WriteLine($"Image Error (URL: {product.ProductImageUrl}): {ex.Message}"); product.ProductImage = null; }
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
            //optionPopup.SetLogo(appLogo);
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
            if (inactivityTimer != null)
            {
                inactivityTimer.Stop();
                inactivityTimer.Dispose();
                inactivityTimer = null;
            }

            if (pageToShow == pageSelectStage)
            {
                inactivityTimer = new System.Windows.Forms.Timer();
                inactivityTimer.Interval = 30000;
                inactivityTimer.Tick += InactivityTimer_Tick;
                inactivityTimer.Start();
            }

            foreach (Control page in this.Controls)
            {
                if (page is UserControl && page != optionPopup && page != pointsPopup && page != cardPopup && page != storePointPopup && page != newMemberPopup)
                    page.Visible = (page == pageToShow);
            }
        }

        private async void OnProceedToPaymentClicked(object sender, CartEventArgs e)
        {
            await pagePayment.PopulateCart(e.ShoppingCart);
            ShowPage(pagePayment);
        }
    }
}