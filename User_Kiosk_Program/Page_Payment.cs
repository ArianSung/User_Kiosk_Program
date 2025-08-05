// Page_Payment.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Payment : UserControl
    {
        public event EventHandler BackButtonClicked;

        // 장바구니 데이터를 컨트롤 내에서 관리하기 위한 리스트
        private List<OrderItem> currentCart;

        public Page_Payment()
        {
            InitializeComponent();
            btn_Back.Click += (s, e) => BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        // MainControl로부터 장바구니 목록을 받아와 화면을 구성하는 메서드
        public void PopulateCart(List<OrderItem> shoppingCart)
        {
            this.currentCart = shoppingCart;
            RenderCart();
        }

        // 장바구니의 현재 상태를 기반으로 화면을 다시 그리는 메서드
        private void RenderCart()
        {
            flp_Payment_Cart.Controls.Clear(); // 패널 초기화

            if (currentCart == null || currentCart.Count == 0)
            {
                UpdateTotalPrice();
                return;
            }

            foreach (var item in currentCart)
            {
                // 각 주문 항목에 대한 Panel을 동적으로 생성
                Panel itemPanel = CreateItemPanel(item);
                flp_Payment_Cart.Controls.Add(itemPanel);
            }

            UpdateTotalPrice();
        }

        // 주문 항목 하나를 표시할 Panel을 생성하는 메서드
        private Panel CreateItemPanel(OrderItem item)
        {
            // 메인 컨테이너 패널
            Panel mainPanel = new Panel
            {
                Width = 580,
                Height = 120,
                Margin = new Padding(0, 0, 0, 5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = item // 나중에 참조할 수 있도록 OrderItem 객체를 Tag에 저장
            };

            // 1. 상품 이미지
            PictureBox picProduct = new PictureBox
            {
                Image = item.BaseProduct.ProductImage,
                Location = new Point(15, 15),
                Size = new Size(90, 90),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // 2. 상품명
            Label lblProductName = new Label
            {
                Text = item.BaseProduct.ProductName,
                Location = new Point(120, 18),
                Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point),
                AutoSize = true
            };

            // 3. 선택 옵션
            var optionsText = string.Join(", ", item.SelectedOptions.Values.Select(opt => opt.OptionName));
            Label lblOptions = new Label
            {
                Text = "- " + optionsText,
                Location = new Point(125, 50),
                Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.DimGray,
                AutoSize = true
            };

            // 4. 수량 조절
            Button btnMinus = new Button { Text = "-", Location = new Point(125, 80), Size = new Size(30, 30) };
            Label lblQuantity = new Label { Text = item.Quantity.ToString(), Location = new Point(160, 80), Size = new Size(40, 30), Font = new Font("맑은 고딕", 12F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            Button btnPlus = new Button { Text = "+", Location = new Point(205, 80), Size = new Size(30, 30) };

            // 5. 가격
            Label lblPrice = new Label
            {
                Text = $"₩ {item.TotalPrice:N0}",
                Location = new Point(440, 80),
                Size = new Size(120, 30),
                Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // 6. 삭제 버튼
            Button btnRemove = new Button
            {
                Text = "X",
                Size = new Size(24, 24),
                Location = new Point(mainPanel.Width - 30, 5),
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRemove.FlatAppearance.BorderSize = 0;

            

            // 컨트롤들을 메인 패널에 추가
            mainPanel.Controls.Add(picProduct);
            mainPanel.Controls.Add(lblProductName);
            mainPanel.Controls.Add(lblOptions);
            mainPanel.Controls.Add(btnMinus);
            mainPanel.Controls.Add(lblQuantity);
            mainPanel.Controls.Add(btnPlus);
            mainPanel.Controls.Add(lblPrice);
            mainPanel.Controls.Add(btnRemove);
  

            // 이벤트 핸들러 연결
            btnPlus.Click += (s, e) => { item.Quantity++; RenderCart(); };
            btnMinus.Click += (s, e) => { if (item.Quantity > 1) { item.Quantity--; RenderCart(); } };
            btnRemove.Click += (s, e) => { currentCart.Remove(item); RenderCart(); };
            // 옵션 수정 버튼은 추후 기능 구현 필요
            // btnEditOptions.Click += ...

            return mainPanel;
        }

        //총 결제 금액을 업데이트하는 메서드
        private void UpdateTotalPrice()
        {
            if (currentCart != null && currentCart.Any())
            {
                decimal totalPrice = currentCart.Sum(item => item.TotalPrice);
                lbl_TotalPrice.Text = $"총 결제 금액: ₩ {totalPrice:N0}";
            }
            else
            {
                lbl_TotalPrice.Text = "총 결제 금액: ₩ 0";
            }
        }
    }
}