using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Pop_Option_Drink : UserControl
    {
        public event EventHandler<OrderItemEventArgs> ConfirmClicked;
        public event EventHandler CancelClicked;

        private Product currentProduct;
        private Dictionary<int, Option> selectedOptions = new Dictionary<int, Option>();

        public Pop_Option_Drink()
        {
            InitializeComponent();
            btn_Confirm.Click += Btn_Confirm_Click;
            btn_Cancel.Click += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetProduct(Product product)
        {
            currentProduct = product;

            // UI 초기화
            selectedOptions.Clear();
            pn_Option.Controls.Clear();
            lbl_ProductName.Text = product.ProductName;
            lbl_ProductPrice.Text = $"{product.BasePrice:N0}원";
            pb_Select_Image.Image = product.ProductImage;
            lb_Select_Info.Text = product.ProductDescription;

            GenerateDynamicControls(product.OptionGroups);
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            // 필수 옵션 검사
            foreach (var group in currentProduct.OptionGroups)
            {
                if (group.IsRequired && !selectedOptions.ContainsKey(group.GroupId))
                {
                    MessageBox.Show($"'{group.GroupName}'은(는) 필수 선택 항목입니다.", "알림");
                    return;
                }
            }

            // 선택된 상품과 옵션들로 OrderItem 객체 생성
            var orderItem = new OrderItem(currentProduct, selectedOptions);

            // OrderItem 객체를 담아 이벤트 발생
            ConfirmClicked?.Invoke(this, new OrderItemEventArgs(orderItem));
        }

        private void GenerateDynamicControls(List<OptionGroup> optionGroups)
        {
            if (optionGroups == null || optionGroups.Count == 0) return;

            FlowLayoutPanel mainFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false
            };
            pn_Option.Controls.Add(mainFlowPanel);

            foreach (var group in optionGroups)
            {
                Panel pn_Header = new Panel
                {
                    Width = mainFlowPanel.ClientSize.Width - 20,
                    Height = 33,
                    BackColor = Color.WhiteSmoke,
                    Margin = new Padding(0, 10, 0, 0)
                };
                Label lblHeader = new Label { Text = group.GroupName, Font = new Font("맑은 고딕", 12F, FontStyle.Bold), Location = new Point(13, 5), AutoSize = true };
                pn_Header.Controls.Add(lblHeader);
                mainFlowPanel.Controls.Add(pn_Header);

                FlowLayoutPanel buttonsPanel = new FlowLayoutPanel
                {
                    Width = mainFlowPanel.ClientSize.Width - 15,
                    AutoSize = true,
                    Padding = new Padding(8, 5, 8, 5)
                };
                mainFlowPanel.Controls.Add(buttonsPanel);

                foreach (var option in group.Options)
                {
                    string priceText = "";
                    if (option.AdditionalPrice > 0)
                    {
                        priceText = $"+{option.AdditionalPrice:N0}원";
                    }
                    else if (option.AdditionalPrice < 0)
                    {
                        priceText = $"{option.AdditionalPrice:N0}원"; // 음수일 경우 C#이 자동으로 '-'를 붙여줌
                    }
                    // 0원일 경우 아무것도 표시하지 않음

                    Button btnOption = new Button
                    {
                        Size = new Size(95, 95),
                        Text = $"{option.OptionName}\n{priceText}", // 수정된 가격 텍스트 사용
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("맑은 고딕", 9F),
                        Tag = option
                    };

                    StyleAndWireButton(btnOption, group);
                    buttonsPanel.Controls.Add(btnOption);
                }
            }
        }

        private void StyleAndWireButton(Button btn, OptionGroup group)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.LightGray;

            btn.Click += (s, e) => {
                var clickedOption = (Option)btn.Tag;

                // 같은 그룹 내 다른 버튼들은 모두 선택 해제
                foreach (Control c in btn.Parent.Controls)
                {
                    if (c is Button)
                    {
                        c.BackColor = Color.White;
                        (c as Button).FlatAppearance.BorderColor = Color.LightGray;
                    }
                }

                // 현재 클릭된 버튼만 선택
                btn.BackColor = Color.SkyBlue;
                btn.FlatAppearance.BorderColor = Color.DodgerBlue;

                // 선택된 옵션을 Dictionary에 저장 (그룹 ID를 키로 사용)
                selectedOptions[group.GroupId] = clickedOption;
            };
        }
    }
    public class OrderItemEventArgs : EventArgs
    {
        public OrderItem Item { get; }
        public OrderItemEventArgs(OrderItem item)
        {
            Item = item;
        }
    }
}