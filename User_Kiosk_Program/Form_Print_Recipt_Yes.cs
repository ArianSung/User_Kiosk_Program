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
    public partial class Form_Print_Recipt_Yes : Form
    {
        private int _orderNumber;   // ✅ 외부에서 받은 주문번호
        private int _pointUsed;

        public Form_Print_Recipt_Yes(int orderNumber, int pointUsed)
        {
            InitializeComponent();

            this._orderNumber = orderNumber;
            this._pointUsed = pointUsed;

            SetReceipt(); // 영수증 내용 설정

            this.FormBorderStyle = FormBorderStyle.None;

            timer1.Interval = 10000; // 10초 후 자동 닫힘
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void SetReceipt()
        {
            string formattedOrderNum = _orderNumber.ToString("D3");
            lb_Order_Num.Text = $"주문번호 : {formattedOrderNum}";

            int totalAmount = 24000; // 예시 총 금액
            int finalAmount = totalAmount - _pointUsed;

            lb_Recipt_text.Text =
                $"------------------------------\n" +
                $"       [영수증 Receipt]\n" +
                $"------------------------------\n" +
                $"메뉴1      1개   8,000원\n" +
                $"메뉴2      2개  16,000원\n" +
                $"------------------------------\n" +
                $"합계             {totalAmount:N0}원\n" +
                (_pointUsed > 0 ? $"포인트 사용    -{_pointUsed:N0}원\n" : "") +
                $"결제 금액       {finalAmount:N0}원\n" +
                $"결제방법: 카드\n" +
                $"------------------------------\n" +
                $"감사합니다 :)";

            lb_Confirm.Text = $"주문 {formattedOrderNum}이 접수되었습니다.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            // 메인화면으로 돌아감
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                Pop_Point popPoint = new Pop_Point();
                mainForm.ShowUserControl(popPoint);
            }

            this.Close();
        }
    }
}
