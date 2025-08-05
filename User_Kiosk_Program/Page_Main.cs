using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Main : UserControl
    {
        public event EventHandler<ProductSelectedEventArgs> ProductSelected;

        private List<OrderItem> shoppingCart = new List<OrderItem>();
        private List<Category> categories;
        private Dictionary<int, List<Product>> productsByCategory = new Dictionary<int, List<Product>>();
        private int currentCategoryId = -1;
        private int currentPage = 1;
        private int totalPages = 1;

        // 터치 스크롤 관련 변수
        private bool isTouching = false;
        private Point touchStartPoint;
        private int startScrollOffset;

        private readonly HttpClient httpClient = new HttpClient();
        private FlowLayoutPanel flp_Menu_Board;
        private System.Windows.Forms.Timer slideTimer = new System.Windows.Forms.Timer { Interval = 10 };
        private const int SLIDE_PIXELS_PER_TICK = 50;

        public Page_Main()
        {
            InitializeComponent();
            slideTimer.Tick += SlideTimer_Tick;
            btn_Prev.Click += btn_Prev_Click;
            btn_Next.Click += btn_Next_Click;

            // 터치 스크롤 이벤트 핸들러 (MouseEnter/Leave는 제거)
            flp_Cart.MouseDown += Flp_Cart_MouseDown;
            flp_Cart.MouseMove += Flp_Cart_MouseMove;
            flp_Cart.MouseUp += Flp_Cart_MouseUp;
        }

        public void AddItemToCart(OrderItem item)
        {
            shoppingCart.Add(item);
            UpdateCartView();
        }

        private void UpdateCartView()
        {
            flp_Cart.Controls.Clear();
            foreach (var item in shoppingCart)
            {
                // 1. 패널 높이를 170으로 줄여 세로 스크롤 문제 해결
                var itemPanel = new Panel { Size = new Size(140, 150), Margin = new Padding(5), BorderStyle = BorderStyle.FixedSingle, Tag = item };

                var pic = new PictureBox { Image = item.BaseProduct.ProductImage, SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 90 };
                var btnRemove = new Button { Text = "X", Size = new Size(20, 20), BackColor = Color.LightCoral, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnRemove.FlatAppearance.BorderSize = 0;
                btnRemove.Location = new Point(itemPanel.Width - btnRemove.Width - 2, 2);
                btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                // 2. 이름 라벨의 Dock을 Fill로 변경하여 위치 문제 해결
                var nameLabel = new Label { Text = item.BaseProduct.ProductName, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

                var qtyPanel = new Panel { Dock = DockStyle.Bottom, Height = 30 };
                var btnMinus = new Button { Text = "-", Dock = DockStyle.Left, Width = 30 };
                var btnPlus = new Button { Text = "+", Dock = DockStyle.Right, Width = 30 };
                var lblQty = new Label { Text = item.Quantity.ToString(), Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

                btnPlus.Click += (s, e) => { item.Quantity++; lblQty.Text = item.Quantity.ToString(); };
                btnMinus.Click += (s, e) => { if (item.Quantity > 1) { item.Quantity--; lblQty.Text = item.Quantity.ToString(); } };
                btnRemove.Click += (s, e) => { shoppingCart.Remove(item); UpdateCartView(); };

                qtyPanel.Controls.Add(btnMinus);
                qtyPanel.Controls.Add(btnPlus);
                qtyPanel.Controls.Add(lblQty);

                // 컨트롤 추가 순서 변경
                itemPanel.Controls.Add(nameLabel); // Fill 속성인 라벨을 먼저 추가
                itemPanel.Controls.Add(pic);
                itemPanel.Controls.Add(btnRemove);
                itemPanel.Controls.Add(qtyPanel);

                // 삭제 버튼을 최상위로
                btnRemove.BringToFront();

                flp_Cart.Controls.Add(itemPanel);
            }
        }

        // ... (InitializePage, LoadAndPrepareData 등 이하 모든 코드는 이전과 동일)

        public async void InitializePage(OrderType orderType, long orderId)
        {
            flp_Categories.Controls.Clear();
            pn_BoardContainer.Controls.Clear();
            flp_Menu_Board = CreateNewMenuBoard();
            pn_BoardContainer.Controls.Add(flp_Menu_Board);
            await LoadAndPrepareData();
            if (categories != null && categories.Count > 0)
            {
                DisplayCategory(categories.First().CategoryId);
            }
        }

        private async Task LoadAndPrepareData()
        {
            categories = await Task.Run(() => DatabaseManager.Instance.GetCategories());
            foreach (var category in categories)
            {
                var btn = new Button { Text = string.IsNullOrEmpty(category.CategoryName) ? "이름없음" : category.CategoryName, Tag = category.CategoryId, Size = new Size(110, 60), Margin = new Padding(5) };
                btn.Click += CategoryButton_Click;
                flp_Categories.Controls.Add(btn);

                var products = await Task.Run(() => DatabaseManager.Instance.GetProductsByCategory(category.CategoryId));
                productsByCategory[category.CategoryId] = products;

                var imageLoadTasks = new List<Task>();
                foreach (var product in products)
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
    }
    public class ProductSelectedEventArgs : EventArgs
    {
        public Product SelectedProduct { get; }
        public ProductSelectedEventArgs(Product product)
        {
            SelectedProduct = product;
        }
    }
}