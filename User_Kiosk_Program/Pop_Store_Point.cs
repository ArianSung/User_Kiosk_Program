using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Pop_Store_Point : UserControl
    {
        public event EventHandler<string> ConfirmClicked; // 전화번호를 전달
        public event EventHandler SkipClicked; // '적립 안함' 또는 '취소'

        public Pop_Store_Point()
        {
            InitializeComponent(); // 디자이너에 txt_PhoneNumber, btn_Confirm, btn_Skip 버튼 필요

            btn_Num1.Click += Keypad_Click;
            btn_Num2.Click += Keypad_Click;
            btn_Num3.Click += Keypad_Click;
            btn_Num4.Click += Keypad_Click;
            btn_Num5.Click += Keypad_Click;
            btn_Num6.Click += Keypad_Click;
            btn_Num7.Click += Keypad_Click;
            btn_Num8.Click += Keypad_Click;
            btn_Num9.Click += Keypad_Click;
            btn_Num0.Click += Keypad_Click;
            btn_Clear.Click += (s, e) => { txt_PhoneNumber.Text = ""; };
            btn_Backspace.Click += (s, e) =>
            {
                if (txt_PhoneNumber.Text.Length > 0)
                    txt_PhoneNumber.Text = txt_PhoneNumber.Text.Substring(0, txt_PhoneNumber.Text.Length - 1);
            };
            btn_Confirm.Click += Btn_Confirm_Click;
            btn_Skip.Click += (s, e) => SkipClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Keypad_Click(object sender, EventArgs e)
        {
            txt_PhoneNumber.Text += (sender as Button).Text;
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            string phone = txt_PhoneNumber.Text;
            // 전화번호 유효성 검사
            if (phone.StartsWith("010") && phone.Length == 11)
            {
                ConfirmClicked?.Invoke(this, phone);
            }
            else
            {
                MessageBox.Show("올바른 전화번호 11자리를 입력해주세요. (010으로 시작)", "입력 오류");
            }
        }

        public void Clear() { txt_PhoneNumber.Text = ""; }
    }
}
