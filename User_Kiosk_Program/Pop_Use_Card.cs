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
    public partial class Pop_Use_Card : UserControl
    {
        public event EventHandler PaymentConfirmed;
        public event EventHandler CancelClicked;

        public Pop_Use_Card()
        {
            InitializeComponent(); // 디자이너에 btn_Pay, btn_Cancel 버튼 필요
            btn_Pay.Click += (s, e) => PaymentConfirmed?.Invoke(this, EventArgs.Empty);
            btn_Cancel.Click += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
        }
        public void SetTheme(Color confirmColor, Color cancelColor, Color panelColor)
        {
            // 1. 페이지 전체 배경색을 설정합니다.
            this.BackColor = panelColor;

            // 3. '담기' 버튼의 스타일을 설정합니다.
            btn_Pay.BackColor = confirmColor;
            btn_Pay.ForeColor = Color.White;
            btn_Pay.FlatStyle = FlatStyle.Flat;
            btn_Pay.FlatAppearance.BorderSize = 0;

            

            btn_Cancel.BackColor = cancelColor;   // '결제하기' 버튼 배경색
            btn_Cancel.ForeColor = Color.White;  // 글자색은 흰색으로 고정 (또는 DB에서 가져오기)
            btn_Cancel.FlatStyle = FlatStyle.Flat;
            btn_Cancel.FlatAppearance.BorderSize = 0;
        }

    }
}
