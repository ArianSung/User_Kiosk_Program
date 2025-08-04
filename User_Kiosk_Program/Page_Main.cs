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
        private List<Category> categories;
        private Dictionary<int, List<Product>> productsByCategory = new Dictionary<int, List<Product>>();
        private int currentCategoryId = -1;
        private int currentPage = 1;
        private int totalPages = 1;

        private readonly HttpClient httpClient = new HttpClient();
        private FlowLayoutPanel flp_Menu_Board;
        private System.Windows.Forms.Timer slideTimer = new System.Windows.Forms.Timer { Interval = 5 };
        private const int SLIDE_PIXELS_PER_TICK = 50;

        public Page_Main()
        {
            InitializeComponent();
            slideTimer.Tick += SlideTimer_Tick;
            btn_Prev.Click += btn_Prev_Click;
            btn_Next.Click += btn_Next_Click;
        }

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
            // 1. 카테고리와 상품 정보(URL 포함)를 먼저 로드합니다.
            categories = await Task.Run(() => DatabaseManager.Instance.GetCategories());
            foreach (var category in categories)
            {
                var btn = new Button
                {
                    Text = string.IsNullOrEmpty(category.CategoryName) ? "이름없음" : category.CategoryName,
                    Tag = category.CategoryId,
                    Size = new Size(110, 60),
                    Margin = new Padding(5)
                };
                btn.Click += CategoryButton_Click;
                flp_Categories.Controls.Add(btn);

                var products = await Task.Run(() => DatabaseManager.Instance.GetProductsByCategory(category.CategoryId));
                productsByCategory[category.CategoryId] = products;
            }

            // 2. 로드된 모든 상품의 URL을 이용해 이미지를 백그라운드에서 다운로드 및 리사이징합니다.
            var imageLoadTasks = new List<Task>();
            foreach (var productList in productsByCategory.Values)
            {
                foreach (var product in productList)
                {
                    if (!string.IsNullOrEmpty(product.ProductImageUrl))
                    {
                        imageLoadTasks.Add(Task.Run(async () =>
                        {
                            try
                            {
                                var imageStream = await httpClient.GetStreamAsync(product.ProductImageUrl);
                                var originalImage = Image.FromStream(imageStream);
                                product.ProductImage = ImageHelper.ResizeImage(originalImage, new Size(140, 110));
                                originalImage.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"이미지 처리 실패 (URL: {product.ProductImageUrl}): {ex.Message}");
                                product.ProductImage = null;
                            }
                        }));
                    }
                }
            }
            await Task.WhenAll(imageLoadTasks);
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

            var currentProducts = productsByCategory[currentCategoryId]
                                .Skip((currentPage - 1) * 9).Take(9).ToList();

            foreach (var product in currentProducts)
            {
                var pn_Menu = new Panel { Size = new Size(150, 170), Margin = new Padding(25, 25, 20, 20), Tag = product };
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

        private async void ProductPanel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            var product = panel.Tag as Product;

            product.OptionGroups = await Task.Run(() => DatabaseManager.Instance.GetOptionsForProduct(product.ProductId));

            string message = $"상품: {product.ProductName}\n";
            foreach (var group in product.OptionGroups)
            {
                message += $"\n- {group.GroupName}:\n";
                foreach (var option in group.Options)
                {
                    message += $"  - {option.OptionName} (+{option.AdditionalPrice}원)\n";
                }
            }
            MessageBox.Show(message, "옵션 정보");
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
    }
}