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
    public partial class Pop_Print_Recipt : UserControl
    {
        private System.Windows.Forms.Timer _autoCloseTimer;

        public Pop_Print_Recipt()
        {
            InitializeComponent();
            timer1.Interval = 10000; // 10초
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                // 또는 다음 화면으로 전환
            }
        }
    }
}
