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
        private Page_Payment pagePayment;

        // optionPopup만 남기고 popupOverlay 필드는 삭제합니다.
        private Pop_Option_Drink optionPopup;

        private List<Category> preloadedCategories;
        private Dictionary<int, List<Product>> preloadedProducts;

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
            pagePayment = new Page_Payment();

            this.Controls.Add(pageDefault);
            this.Controls.Add(pageSelectStage);
            this.Controls.Add(pageMain);
            this.Controls.Add(pagePayment);
            foreach (Control page in this.Controls)
            {
                page.Dock = DockStyle.Fill;
                page.Visible = false;
            }

            InitializePopup();

            pageDefault.ScreenClicked += OnDefaultPageScreenClicked;
            pageSelectStage.OrderTypeSelected += OnOrderTypeSelected;
            pageMain.ProceedToPaymentClicked += PageMain_ProceedToPaymentClicked;
            pageMain.ProductSelected += OnProductSelected;
            pagePayment.BackButtonClicked += (s, ev) => ShowPage(pageMain);

            await Task.WhenAll(LoadDefaultPageData(), LoadMainPageData());

            pageMain.SetInitialData(preloadedCategories, preloadedProducts);
            ShowPage(pageDefault);
            this.Cursor = Cursors.Default;
        }

        private void PageMain_ProceedToPaymentClicked(object? sender, CartEventArgs e)
        {
            // 1. 결제 페이지(UserControl)에 장바구니 데이터를 채워줍니다.
            pagePayment.PopulateCart(e.ShoppingCart);

            // 2. 결제 페이지를 화면에 보여줍니다.
            ShowPage(pagePayment);
        }

        private async void OnProductSelected(object sender, ProductSelectedEventArgs e)
        {
            var product = e.SelectedProduct;
            product.OptionGroups = await Task.Run(() => DatabaseManager.Instance.GetOptionsForProduct(product.ProductId));
            ShowOptionPopup(product);
        }

        // 팝업 관리 메서드들 (popupOverlay 관련 코드 모두 삭제)
        private void InitializePopup()
        {
            optionPopup = new Pop_Option_Drink { Visible = false, Size = new Size(600, 720), Location = new Point((this.Width - 600) / 2, (this.Height - 720) / 2), Anchor = AnchorStyles.None };
            this.Controls.Add(optionPopup);

            optionPopup.ConfirmClicked += OptionPopup_ConfirmClicked;
            optionPopup.CancelClicked += (s, e) => HideOptionPopup();
        }

        private void OptionPopup_ConfirmClicked(object? sender, OrderItemEventArgs e)
        {
            // Page_Main의 장바구니에 아이템 추가
            pageMain.AddItemToCart(e.Item);

            // 팝업 닫기
            HideOptionPopup();
        }

        private void ShowOptionPopup(Product product)
        {
            optionPopup.SetProduct(product);
            optionPopup.BringToFront(); // 팝업만 맨 앞으로 가져옵니다.
            optionPopup.Visible = true;
        }

        private void HideOptionPopup()
        {
            optionPopup.Visible = false;
        }

        // 페이지 전환 및 데이터 로딩 로직 (이하 동일)
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

        private void OnProceedToPaymentClicked(object sender, CartEventArgs e)
        {
            // 결제 페이지에 장바구니 데이터를 채우고
            pagePayment.PopulateCart(e.ShoppingCart);
            // 결제 페이지를 화면에 보여줌
            ShowPage(pagePayment);
        }
    }
}