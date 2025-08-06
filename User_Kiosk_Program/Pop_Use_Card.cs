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
        
    }
}
