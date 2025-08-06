using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Payment : UserControl
    {
        public event EventHandler<CartEventArgs> BackButtonClicked;
        public event EventHandler<PointPaymentEventArgs> PointPaymentClicked;
        public event EventHandler<CreditCardEventArgs> CreditCardPaymentClicked;

        private List<OrderItem> currentCart;
        private decimal orderAmount = 0; // 주문 금액은 decimal 유지
        private int pointsUsed = 0;      // decimal -> int
        private readonly HttpClient httpClient = new HttpClient();
        private Member pointUser = null;

        public Page_Payment()
        {
            InitializeComponent();
            btn_Back.Click += (s, e) => BackButtonClicked?.Invoke(this, new CartEventArgs(this.currentCart));

        }

        // MainControl로부터 장바구니 목록을 받아와 화면을 구성하는 메서드
        public async Task PopulateCart(List<OrderItem> shoppingCart)
        {
            this.currentCart = shoppingCart;
            this.orderAmount = shoppingCart.Sum(item => item.TotalPrice);
            this.pointsUsed = 0;
            RenderCartItems();
            UpdatePaymentSummary();
            await LoadPaymentMethodsAsync();
        }

        // MainControl로부터 받은 포인트 사용 회원 정보를 저장
        public void SetPointUser(Member member)
        {
            this.pointUser = member;
        }

        // 결제 금액 관련 UI만 업데이트하는 메서드
        private void UpdatePaymentSummary()
        {
            this.orderAmount = currentCart.Sum(item => item.TotalPrice);
            lbl_OrderAmount.Text = $"₩ {this.orderAmount:N0}";
            lbl_PointsUsed.Text = $"- ₩ {this.pointsUsed:N0}"; // int 값도 N0 포맷으로 표시 가능
            decimal finalAmount = this.orderAmount - this.pointsUsed;
            lbl_FinalAmount.Text = $"₩ {finalAmount:N0}";
        }

        // MainControl이 호출할, 포인트를 적용하는 공개 메서드
        public void ApplyPoints(int pointsToUse) // decimal -> int
        {
            // int와 decimal 중 작은 값을 비교하기 위해 캐스팅
            this.pointsUsed = (int)Math.Min(this.orderAmount, pointsToUse);
            UpdatePaymentSummary();
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

        // 주문 항목 패널 생성 메서드
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

        // 결제 수단을 동적으로 로드하고 표시하는 메서드
        private async Task LoadPaymentMethodsAsync()
        {
            fl_Payments.Controls.Clear();
            List<PaymentMethod> methods = await Task.Run(() => DatabaseManager.Instance.GetPaymentMethods());
            var imageLoadTasks = new List<Task>();

            foreach (var method in methods)
            {
                var pbox = new PictureBox
                {
                    Size = new Size(100, 90),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Gainsboro, // 이미지가 로드되기 전의 배경색
                    Tag = method,
                    Cursor = Cursors.Hand
                };
                // DB의 payment_image 필드에 실제 URL이 있다면, 해당 URL에서 이미지를 비동기로 로드합니다.
                if (!string.IsNullOrEmpty(method.PaymentImageUrl))
                {
                    imageLoadTasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            var imageStream = await httpClient.GetStreamAsync(method.PaymentImageUrl);
                            var image = Image.FromStream(imageStream);
                            method.PaymentImage = image;

                            pbox.Invoke((Action)(() => pbox.Image = ImageHelper.ResizeImage(image, pbox.Size)));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Payment image load error for {method.PaymentName}: {ex.Message}");
                        }
                    }));
                }

                pbox.Click += PaymentMethod_Click;
                fl_Payments.Controls.Add(pbox);
            }
            await Task.WhenAll(imageLoadTasks);
        }

        /// <summary>
        /// * 병합과정에서 겹침
        /// </summary>
        /// <param name="mainColor"></param>
        /// <param name="panelColor"></param>
        // 테마세팅
        public void SetTheme(Color mainColor, Color panelColor)
        {

            //btn_GotoPay.BackColor = mainColor;

            this.BackColor = panelColor;
        }


        // 결제 방식 PictureBox를 클릭했을 때 호출되는 이벤트 핸들러
        private void PaymentMethod_Click(object sender, EventArgs e)
        {
            var method = (sender as PictureBox).Tag as PaymentMethod;
            if (method == null) return;

            if (method.PaymentName.ToLower() == "point")
            {
                PointPaymentClicked?.Invoke(this, new PointPaymentEventArgs(this.orderAmount, this.pointUser));
            }
            else if (method.PaymentName.ToLower() == "credit_card")
            {
                decimal finalAmount = this.orderAmount - this.pointsUsed;
                CreditCardPaymentClicked?.Invoke(this, new CreditCardEventArgs(finalAmount, this.pointsUsed, this.pointUser));
            }
            else
            {
                MessageBox.Show($"'{method.PaymentName}' 결제 방식을 선택했습니다.");
            }
        }

        public void SetLogo(Image logoImage)
        {
            if (logoImage != null && pb_Logo != null)
            {
                pb_Logo.Image = ImageHelper.ResizeImage(logoImage, pb_Logo.Size);
            }
        }
    }

    // 카드 결제 정보를 담아 보낼 EventArgs
    public class CreditCardEventArgs : EventArgs
    {
        public decimal FinalAmount { get; }
        public int PointsUsed { get; } // decimal -> int
        public Member PointUser { get; }

        public CreditCardEventArgs(decimal finalAmount, int pointsUsed, Member pointUser) // decimal -> int
        {
            FinalAmount = finalAmount;
            PointsUsed = pointsUsed;
            PointUser = pointUser;
        }
    }
    public class PointPaymentEventArgs : EventArgs
    {
        public decimal OrderAmount { get; }
        public Member PointUser { get; }

        public PointPaymentEventArgs(decimal orderAmount, Member pointUser)
        {
            OrderAmount = orderAmount;
            PointUser = pointUser;
        }
    }
}
