using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Payment : UserControl
    {
        public event EventHandler<CartEventArgs> BackButtonClicked;

        private List<OrderItem> currentCart;
        private decimal orderAmount = 0;
        private decimal pointsUsed = 0;

        public Page_Payment()
        {
            InitializeComponent();
            btn_Back.Click += (s, e) => BackButtonClicked?.Invoke(this, new CartEventArgs(this.currentCart));

            btn_Pay.Click += Btn_Pay_Click;
        }

        // 결제하기 버튼 클릭 시
        private void Btn_Pay_Click(object sender, EventArgs e)
        {
            decimal finalAmount = orderAmount - pointsUsed;
            MessageBox.Show($"₩ {finalAmount:N0}을(를) 결제합니다.", "결제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: 실제 결제 로직 및 영수증 출력 등 추가
        }

        // 포인트 적용 버튼 클릭 시


        // MainControl로부터 장바구니 목록을 받아와 화면을 구성하는 메서드
        public void PopulateCart(List<OrderItem> shoppingCart)
        {
            this.currentCart = shoppingCart;
            this.orderAmount = shoppingCart.Sum(item => item.TotalPrice);
            this.pointsUsed = 0; // 새 카트를 받으면 포인트 사용 초기화


            RenderCartItems();
            UpdatePaymentSummary();
        }

        // 결제 금액 관련 UI만 업데이트하는 메서드
        private void UpdatePaymentSummary()
        {
            lbl_OrderAmount.Text = $"₩ {this.orderAmount:N0}";
            lbl_PointsUsed.Text = $"- ₩ {this.pointsUsed:N0}";

            decimal finalAmount = this.orderAmount - this.pointsUsed;
            lbl_FinalAmount.Text = $"₩ {finalAmount:N0}";
        }

        // 장바구니 항목들만 화면에 다시 그리는 메서드
        private void RenderCartItems()
        {
            flp_Payment_Cart.Controls.Clear();

            if (currentCart == null) return;

            foreach (var item in currentCart)
            {
                Panel itemPanel = CreateItemPanel(item);
                flp_Payment_Cart.Controls.Add(itemPanel);
            }
        }

        // 주문 항목 패널 생성 메서드 (이전과 동일, 수량 변경 시 전체 금액 업데이트 로직 추가)
        private Panel CreateItemPanel(OrderItem item)
        {
            Panel mainPanel = new Panel
            {
                Width = 580,
                Height = 140,
                Margin = new Padding(0, 0, 0, 5),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Tag = item
            };
            PictureBox picProduct = new PictureBox { Image = item.BaseProduct.ProductImage, Location = new Point(15, 15), Size = new Size(90, 90), SizeMode = PictureBoxSizeMode.Zoom };
            Label lblProductName = new Label { Text = item.BaseProduct.ProductName, Location = new Point(120, 18), Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold), AutoSize = true };
            var optionsText = string.Join(", ", item.SelectedOptions.Values.Select(opt => opt.OptionName));
            if (optionsText.Length > 70)
            {
                optionsText = optionsText.Substring(0, 70) + "....";
            }
            Label lblOptions = new Label
            {
                Text = "- " + optionsText,
                Location = new Point(125, 50),
                Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.DimGray,
                AutoSize = false,
                Size = new Size(450, 40)
            };
            Button btnMinus = new Button { Text = "-", Location = new Point(125, 100), Size = new Size(30, 30) };
            Label lblQuantity = new Label { Text = item.Quantity.ToString(), Location = new Point(160, 100), Size = new Size(40, 30), Font = new Font("맑은 고딕", 12F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            Button btnPlus = new Button { Text = "+", Location = new Point(205, 100), Size = new Size(30, 30) };
            Label lblPrice = new Label { Text = $"₩ {item.TotalPrice:N0}", Location = new Point(440, 100), Size = new Size(120, 30), Font = new Font("맑은 고딕", 12F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            Button btnRemove = new Button { Text = "X", Size = new Size(24, 24), Location = new Point(mainPanel.Width - 30, 5), BackColor = Color.LightCoral, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnRemove.FlatAppearance.BorderSize = 0;

            mainPanel.Controls.AddRange(new Control[] { picProduct, lblProductName, lblOptions, btnMinus, lblQuantity, btnPlus, lblPrice, btnRemove });


            // 이벤트 핸들러 연결
            btnPlus.Click += (s, e) =>
            {
                // ▼▼▼▼▼ 1. 현재 스크롤 위치 저장 ▼▼▼▼▼
                int scrollPosition = flp_Payment_Cart.VerticalScroll.Value;

                item.Quantity++;
                this.orderAmount = currentCart.Sum(i => i.TotalPrice);
                RenderCartItems();
                UpdatePaymentSummary();

                // ▼▼▼▼▼ 2. 저장했던 스크롤 위치로 복원 ▼▼▼▼▼
                flp_Payment_Cart.VerticalScroll.Value = scrollPosition;
                flp_Payment_Cart.PerformLayout(); // 레이아웃을 즉시 업데이트하여 스크롤 위치 적용
            };
            btnMinus.Click += (s, e) =>
            {
                if (item.Quantity > 1)
                {
                    // ▼▼▼▼▼ 1. 현재 스크롤 위치 저장 ▼▼▼▼▼
                    int scrollPosition = flp_Payment_Cart.VerticalScroll.Value;

                    item.Quantity--;
                    this.orderAmount = currentCart.Sum(i => i.TotalPrice);
                    RenderCartItems();
                    UpdatePaymentSummary();

                    // ▼▼▼▼▼ 2. 저장했던 스크롤 위치로 복원 ▼▼▼▼▼
                    flp_Payment_Cart.VerticalScroll.Value = scrollPosition;
                    flp_Payment_Cart.PerformLayout();
                }
            };
            btnRemove.Click += (s, e) =>
            {
                // 삭제 시에는 목록이 바뀌므로 스크롤을 맨 위로 올리는 것이 자연스러울 수 있습니다.
                // 만약 삭제 시에도 위치를 유지하고 싶다면 위와 동일한 로직을 추가하면 됩니다.
                currentCart.Remove(item);
                this.orderAmount = currentCart.Sum(i => i.TotalPrice);
                RenderCartItems();
                UpdatePaymentSummary();
            };

            return mainPanel;
        }

        public void SetLogo(Image logoImage)
        {
            if (logoImage != null && pb_Logo != null)
            {
                // ▼▼▼▼▼ 이미 만들어져 있는 ImageHelper.ResizeImage 메서드를 사용합니다 ▼▼▼▼▼
                pb_Logo.Image = ImageHelper.ResizeImage(logoImage, pb_Logo.Size);
                // ▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
            }
        }

        // 테마세팅
        public void SetTheme(Color mainColor, Color panelColor)
        {

            //btn_GotoPay.BackColor = mainColor;

            this.BackColor = panelColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_OrderAmount_Click(object sender, EventArgs e)
        {

        }
    }
}