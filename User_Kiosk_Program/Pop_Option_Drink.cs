using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Pop_Option_Drink : UserControl
    {
        public event EventHandler ConfirmClicked;
        public event EventHandler CancelClicked;

        public Pop_Option_Drink()
        {
            InitializeComponent();
            btn_Confirm.Click += (s, e) => ConfirmClicked?.Invoke(this, EventArgs.Empty);
            btn_Cancel.Click += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        // Page_Main으로부터 Product 객체를 통째로 받는 메서드
        public void SetProduct(Product product)
        {
            // 1. UI 초기화
            pn_Option.Controls.Clear();
            lbl_ProductName.Text = product.ProductName;
            lbl_ProductPrice.Text = $"{product.BasePrice:N0}원";
            pb_Select_Image.Image = product.ProductImage; // Page_Main이 미리 로드한 이미지를 바로 사용
            //lb_Select_Info.Text =

            // 2. 받은 Product 객체의 옵션 정보로 동적 컨트롤 생성
            GenerateDynamicControls(product.OptionGroups);
        }

        private void GenerateDynamicControls(List<OptionGroup> optionGroups)
        {
            if (optionGroups == null || optionGroups.Count == 0) return;

            int currentY = 0;
            const int margin = 13;
            const int buttonWidth = 100;
            const int buttonHeight = 100;

            foreach (var group in optionGroups)
            {
                Panel pn_Header = new Panel { Width = 540, Height = 33, BackColor = Color.WhiteSmoke, Location = new Point(0, currentY) };
                Label lblHeader = new Label { Text = group.GroupName, Font = new Font("맑은 고딕", 12F, FontStyle.Bold), Location = new Point(margin, 5), AutoSize = true };
                pn_Header.Controls.Add(lblHeader);
                pn_Option.Controls.Add(pn_Header);

                currentY += pn_Header.Height;

                FlowLayoutPanel buttonsPanel = new FlowLayoutPanel { Width = 540, AutoSize = true, Location = new Point(0, currentY), Padding = new Padding(8, 5, 8, 5) };
                pn_Option.Controls.Add(buttonsPanel);

                foreach (var option in group.Options)
                {
                    Button btnOption = new Button
                    {
                        Size = new Size(buttonWidth, buttonHeight),
                        Text = $"{option.OptionName}\n+{option.AdditionalPrice:N0}원",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("맑은 고딕", 9F),
                        Tag = option
                    };
                    StyleButton(btnOption);
                    buttonsPanel.Controls.Add(btnOption);
                }
                currentY += buttonsPanel.Height;
            }
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.LightGray;

            btn.Click += (s, e) => {
                // TODO: 옵션 선택/해제 로직 구현
                if (btn.BackColor == Color.White)
                {
                    // 같은 그룹 내 다른 버튼들은 모두 선택 해제
                    foreach (Control c in btn.Parent.Controls)
                    {
                        if (c is Button)
                        {
                            c.BackColor = Color.White;
                            (c as Button).FlatAppearance.BorderColor = Color.LightGray;
                        }
                    }
                    // 현재 버튼만 선택
                    btn.BackColor = Color.SkyBlue;
                    btn.FlatAppearance.BorderColor = Color.DodgerBlue;
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.LightGray;
                }
            };
        }
    }
}