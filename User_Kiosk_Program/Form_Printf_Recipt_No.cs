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
    public partial class Form_Printf_Recipt_No : Form
    {
        private int _orderNumber;

        public Form_Printf_Recipt_No(int orderNumber)
        {
            InitializeComponent();
            _orderNumber = orderNumber;

            SetRecipt();

            this.FormBorderStyle = FormBorderStyle.None;

            timer1.Interval = 10000; // 10초
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void SetRecipt()
        {
            string formattedOrderNum = _orderNumber.ToString("D3");
            lb_Order_Num.Text = $"주문번호 : {formattedOrderNum}";
            lb_Confirm.Text = $"주문 {formattedOrderNum}이 접수되었습니다.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (Application.OpenForms["Form1"] is Form1 mainForm)
            {
                Pop_Point popPoint = new Pop_Point();
                mainForm.ShowUserControl(popPoint);
            }
            this.Close(); // 폼 닫기
        }

    }
}
