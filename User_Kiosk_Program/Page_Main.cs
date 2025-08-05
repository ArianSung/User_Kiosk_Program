using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Main : UserControl
    {
        public event EventHandler<CartEventArgs> ProceedToPaymentClicked;
        public event EventHandler<ProductSelectedEventArgs> ProductSelected;

        private List<OrderItem> shoppingCart = new List<OrderItem>();
        private List<Category> categories;
        private Dictionary<int, List<Product>> productsByCategory;

        private int currentCategoryId = -1;
        private int currentPage = 1;
        private int totalPages = 1;

        private bool isTouching = false;
        private Point touchStartPoint;
        private int startScrollOffset;

        private FlowLayoutPanel flp_Menu_Board;
        private System.Windows.Forms.Timer slideTimer = new System.Windows.Forms.Timer { Interval = 10 };
        private const int SLIDE_PIXELS_PER_TICK = 50;

        public Page_Main()
        {
            InitializeComponent();
            slideTimer.Tick += SlideTimer_Tick;
            btn_Prev.Click += btn_Prev_Click;
            btn_Next.Click += btn_Next_Click;
            btn_GotoPay.Click += Btn_GotoPay_Click;
            flp_Cart.MouseDown += Flp_Cart_MouseDown;
            flp_Cart.MouseMove += Flp_Cart_MouseMove;
            flp_Cart.MouseUp += Flp_Cart_MouseUp;
        }

        private void Btn_GotoPay_Click(object? sender, EventArgs e)
        {
            // 장바구니에 항목이 하나 이상 있을 때만 실행
            if (shoppingCart.Any())
            {
                // MainControl에 장바구니 정보를 담아 이벤트를 보냄
                ProceedToPaymentClicked?.Invoke(this, new CartEventArgs(this.shoppingCart));
            }
            else
            {
                MessageBox.Show("장바구니가 비어 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MainControl로부터 미리 로드된 데이터를 받는 메서드
        public void SetInitialData(List<Category> loadedCategories, Dictionary<int, List<Product>> loadedProducts)
        {
            this.categories = loadedCategories;
            this.productsByCategory = loadedProducts;
        }

        // InitializePage는 이제 UI 초기화 및 첫 화면 표시에만 집중합니다.
        public void InitializePage(OrderType orderType, long orderId)
        {
            flp_Categories.Controls.Clear();
            pn_BoardContainer.Controls.Clear();
            flp_Menu_Board = CreateNewMenuBoard();
            pn_BoardContainer.Controls.Add(flp_Menu_Board);

            GenerateCategoryButtons();

            if (categories != null && categories.Count > 0)
            {
                DisplayCategory(categories.First().CategoryId);
            }
        }

        // 카테고리 버튼을 생성하는 로직을 별도 메서드로 분리
        private void GenerateCategoryButtons()
        {
            if (categories == null) return;
            foreach (var category in categories)
            {
                var btn = new Button { Text = string.IsNullOrEmpty(category.CategoryName) ? "이름없음" : category.CategoryName, Tag = category.CategoryId, Size = new Size(110, 60), Margin = new Padding(5), BackColor = Color.White };
                btn.Click += CategoryButton_Click;
                flp_Categories.Controls.Add(btn);
            }
        }

        public void AddItemToCart(OrderItem item)
        {
            shoppingCart.Add(item);
            UpdateCartView();
            // UpdateCartView()가 이미 내부적으로 총 금액을 업데이트하므로,
            // 이 줄은 사실상 생략 가능하지만 명시적으로 남겨둘 수 있습니다.
            UpdateCartTotalPrice();
        }

        private void UpdateCartView()
        {
            flp_Cart.Controls.Clear();
            foreach (var item in shoppingCart)
            {
                var itemPanel = new Panel { Size = new Size(140, 150), Margin = new Padding(5), BorderStyle = BorderStyle.FixedSingle, Tag = item };
                var pic = new PictureBox { Image = item.BaseProduct.ProductImage, SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 90 };
                var btnRemove = new Button { Text = "X", Size = new Size(20, 20), BackColor = Color.LightCoral, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnRemove.FlatAppearance.BorderSize = 0;
                btnRemove.Location = new Point(itemPanel.Width - btnRemove.Width - 2, 2);
                btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                var nameLabel = new Label { Text = item.BaseProduct.ProductName, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
                var qtyPanel = new Panel { Dock = DockStyle.Bottom, Height = 30 };
                var btnMinus = new Button { Text = "-", Dock = DockStyle.Left, Width = 30 };
                var btnPlus = new Button { Text = "+", Dock = DockStyle.Right, Width = 30 };
                var lblQty = new Label { Text = item.Quantity.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

                itemPanel.MouseDown += Flp_Cart_MouseDown;
                itemPanel.MouseMove += Flp_Cart_MouseMove;
                itemPanel.MouseUp += Flp_Cart_MouseUp;
                pic.MouseDown += Flp_Cart_MouseDown;
                pic.MouseMove += Flp_Cart_MouseMove;
                pic.MouseUp += Flp_Cart_MouseUp;
                nameLabel.MouseDown += Flp_Cart_MouseDown;
                nameLabel.MouseMove += Flp_Cart_MouseMove;
                nameLabel.MouseUp += Flp_Cart_MouseUp;

                // ✨ 버튼 클릭 이벤트 핸들러 안에 총 금액 업데이트 호출 추가
                btnPlus.Click += (s, e) => {
                    item.Quantity++;
                    lblQty.Text = item.Quantity.ToString();
                    UpdateCartTotalPrice(); // 총 금액 업데이트
                };
                btnMinus.Click += (s, e) => {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                        lblQty.Text = item.Quantity.ToString();
                        UpdateCartTotalPrice(); // 총 금액 업데이트
                    }
                };
                btnRemove.Click += (s, e) => {
                    shoppingCart.Remove(item);
                    UpdateCartView(); // UI를 다시 그리고 총 금액도 다시 계산됨
                };

                qtyPanel.Controls.Add(btnMinus);
                qtyPanel.Controls.Add(btnPlus);
                qtyPanel.Controls.Add(lblQty);
                itemPanel.Controls.Add(nameLabel);
                itemPanel.Controls.Add(pic);
                itemPanel.Controls.Add(qtyPanel);
                itemPanel.Controls.Add(btnRemove);
                btnRemove.BringToFront();
                flp_Cart.Controls.Add(itemPanel);
            }

            // ✨ 모든 UI 변경 후 마지막에 총 금액을 한 번 더 업데이트
            UpdateCartTotalPrice();
        }

        private void DisplayCategory(int categoryId)
        {
            currentCategoryId = categoryId;
            currentPage = 1;
            int totalItems = productsByCategory.ContainsKey(categoryId) ? productsByCategory[categoryId].Count : 0;
            totalPages = (int)Math.Ceiling(totalItems / 9.0);
            if (totalPages == 0) totalPages = 1;
            PopulatePanel(flp_Menu_Board);
            UpdatePageInfo();
        }

        private void PopulatePanel(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            if (!productsByCategory.ContainsKey(currentCategoryId)) return;
            var currentProducts = productsByCategory[currentCategoryId].Skip((currentPage - 1) * 9).Take(9).ToList();
            foreach (var product in currentProducts)
            {
                var pn_Menu = new Panel { Size = new Size(150, 170), Margin = new Padding(25, 15, 20, 15), Tag = product };
                var pb_Image = new PictureBox { Image = product.ProductImage, Size = new Size(125, 140), Dock = DockStyle.Top, SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Gainsboro };
                var lb_Name = new Label { Text = product.ProductName, Dock = DockStyle.Bottom, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Height = 30 };

                pn_Menu.Controls.Add(pb_Image);
                pn_Menu.Controls.Add(lb_Name);
                panel.Controls.Add(pn_Menu);

                pn_Menu.Click += ProductPanel_Click;
                pb_Image.Click += (s, e) => ProductPanel_Click(pn_Menu, e);
                lb_Name.Click += (s, e) => ProductPanel_Click(pn_Menu, e);
            }
        }

        public void UpdateShoppingCart(List<OrderItem> updatedCart)
        {
            // 전달받은 최신 장바구니 목록으로 교체합니다.
            this.shoppingCart = updatedCart;
            // 변경된 내용으로 장바구니 UI를 다시 그립니다.
            UpdateCartView();
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            var product = panel.Tag as Product;
            if (product != null)
            {
                ProductSelected?.Invoke(this, new ProductSelectedEventArgs(product));
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                DisplayCategory((int)clickedButton.Tag);
            }
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; AnimateSlide(false); }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) { currentPage++; AnimateSlide(true); }
        }

        private void UpdatePageInfo()
        {
            lbl_PageInfo.Text = $"{currentPage} / {totalPages}";
            btn_Prev.Enabled = currentPage > 1;
            btn_Next.Enabled = currentPage < totalPages;
        }

        private FlowLayoutPanel CreateNewMenuBoard()
        {
            return new FlowLayoutPanel { Size = new Size(600, 600), Location = new Point(0, 0), Margin = new Padding(0), Padding = new Padding(0) };
        }

        private void AnimateSlide(bool isNext)
        {
            var flp_Next_Menu_Board = CreateNewMenuBoard();
            flp_Next_Menu_Board.Location = new Point(isNext ? pn_BoardContainer.Width : -pn_BoardContainer.Width, 0);
            pn_BoardContainer.Controls.Add(flp_Next_Menu_Board);
            flp_Next_Menu_Board.BringToFront();
            PopulatePanel(flp_Next_Menu_Board);
            slideTimer.Tag = new Tuple<FlowLayoutPanel, FlowLayoutPanel, bool>(flp_Menu_Board, flp_Next_Menu_Board, isNext);
            slideTimer.Start();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            var panels = (Tuple<FlowLayoutPanel, FlowLayoutPanel, bool>)slideTimer.Tag;
            var oldPanel = panels.Item1;
            var newPanel = panels.Item2;
            bool isNext = panels.Item3;
            int step = SLIDE_PIXELS_PER_TICK;
            oldPanel.Left += isNext ? -step : step;
            newPanel.Left += isNext ? -step : step;
            if ((isNext && newPanel.Left <= 0) || (!isNext && newPanel.Left >= 0))
            {
                slideTimer.Stop();
                newPanel.Location = new Point(0, 0);
                pn_BoardContainer.Controls.Remove(oldPanel);
                oldPanel.Dispose();
                flp_Menu_Board = newPanel;
                UpdatePageInfo();
            }
        }
        private void Flp_Cart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTouching = true;
                touchStartPoint = e.Location;
                startScrollOffset = flp_Cart.HorizontalScroll.Value;
                flp_Cart.Cursor = Cursors.Hand;
            }
        }

        private void Flp_Cart_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTouching)
            {
                int deltaX = e.X - touchStartPoint.X;
                flp_Cart.HorizontalScroll.Value = Math.Max(0, Math.Min(flp_Cart.HorizontalScroll.Maximum, startScrollOffset - deltaX));
            }
        }

        private void Flp_Cart_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTouching = false;
                flp_Cart.Cursor = Cursors.Default;
            }
        }
        private void UpdateCartTotalPrice()
        {
            // shoppingCart에 있는 모든 아이템의 TotalPrice를 합산합니다.
            decimal totalPrice = shoppingCart.Sum(item => item.TotalPrice);
            lbl_CartTotal.Text = $"총 금액: ₩ {totalPrice:N0}";
        }

        public void SetLogo(Image logoImage)
        {
            if (logoImage != null && pb_Logo != null)
            {
                pb_Logo.Image = ImageHelper.ResizeImage(logoImage, pb_Logo.Size);
            }
        }


        // 테마세팅
        public void SetTheme(Color mainColor, Color panelColor)
        {
           
            btn_GotoPay.BackColor = mainColor;

            this.BackColor = panelColor;
        }


    }
    public class ProductSelectedEventArgs : EventArgs
    {
        public Product SelectedProduct { get; }
        public ProductSelectedEventArgs(Product product)
        {
            SelectedProduct = product;
        }
    }
    public class CartEventArgs : EventArgs
    {
        public List<OrderItem> ShoppingCart { get; }
        public CartEventArgs(List<OrderItem> cart)
        {
            ShoppingCart = new List<OrderItem>(cart); // 안전하게 복사본을 전달
        }
    }
}