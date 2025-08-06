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
    public partial class Pop_New_Member : UserControl
    {
        public event EventHandler ConfirmClicked;

        public Pop_New_Member()
        {
            InitializeComponent(); // 디자이너에 "신규사용자입니다" Label과 btn_Confirm 버튼 필요
            btn_Confirm.Click += (s, e) => ConfirmClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
