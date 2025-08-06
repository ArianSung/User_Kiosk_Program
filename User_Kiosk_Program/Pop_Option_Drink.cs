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
            foreach (var group in currentProduct.OptionGroups)
            {
                if (group.IsRequired)
                {
                    // 그룹에 속한 옵션 ID들 중 하나라도 selectedOptions에 포함되어 있는지 확인
                    bool isSelected = group.Options.Any(opt => selectedOptions.ContainsKey(opt.OptionId));
                    if (!isSelected)
                    {
                        MessageBox.Show($"'{group.GroupName}'은(는) 필수 선택 항목입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            var orderItem = new OrderItem(currentProduct, selectedOptions);
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

                if (group.AllowMultiple) // 중복 선택이 가능한 그룹일 경우
                {
                    // 체크박스처럼 동작: 현재 버튼의 선택 상태를 토글
                    if (selectedOptions.ContainsKey(clickedOption.OptionId)) // 이미 선택된 상태라면
                    {
                        btn.BackColor = Color.White;
                        btn.FlatAppearance.BorderColor = Color.LightGray;
                        selectedOptions.Remove(clickedOption.OptionId); // 선택 해제
                    }
                    else // 선택되지 않은 상태라면
                    {
                        btn.BackColor = Color.SkyBlue;
                        btn.FlatAppearance.BorderColor = Color.DodgerBlue;
                        selectedOptions[clickedOption.OptionId] = clickedOption; // 선택
                    }
                }
                else // 단일 선택만 가능한 그룹일 경우
                {
                    bool isAlreadySelected = selectedOptions.ContainsKey(clickedOption.OptionId);

                    // 그룹 내 모든 버튼과 선택 정보를 먼저 초기화
                    foreach (Control c in btn.Parent.Controls)
                    {
                        if (c is Button)
                        {
                            c.BackColor = Color.White;
                            ((Button)c).FlatAppearance.BorderColor = Color.LightGray;
                        }
                    }
                    var groupOptions = group.Options.Select(opt => opt.OptionId);
                    var selectedKeyToRemove = selectedOptions.Keys.FirstOrDefault(key => groupOptions.Contains(key));
                    if (selectedKeyToRemove != 0)
                    {
                        selectedOptions.Remove(selectedKeyToRemove);
                    }

                    // 만약 이전에 선택했던 버튼을 다시 누른게 아니라면, 새로 선택
                    if (!isAlreadySelected)
                    {
                        btn.BackColor = Color.SkyBlue;
                        btn.FlatAppearance.BorderColor = Color.DodgerBlue;
                        selectedOptions[clickedOption.OptionId] = clickedOption;
                    }
                }
            };
        }
        public void SetTheme(Color mainColor, Color panelColor)
        {
            


            this.BackColor = Color.White;
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