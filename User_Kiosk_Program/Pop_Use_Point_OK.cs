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
    public partial class Pop_Use_Point_OK : UserControl
    {
        public Pop_Use_Point_OK()
        {
            InitializeComponent();
        }
        public Pop_Use_Point_OK(int pointUsed)
        {
            InitializeComponent();

            // 전달받은 값을 클래스 변수에 저장합니다.
            _pointUsed = pointUsed;
        }
        private readonly int _pointUsed;

        public void ShowUserControl(UserControl control)
        {
            // 1. pn_Main 패널에 있던 기존 컨트롤들을 모두 지웁니다.
            pn_Use_Point_OK.Controls.Clear();

            // 2. 새로 받은 컨트롤(control)이 패널을 꽉 채우도록 설정합니다.
            control.Dock = DockStyle.Fill;

            // 3. pn_Main 패널에 새 컨트롤을 추가해서 보여줍니다.
            pn_Use_Point_OK.Controls.Add(control);
        }

        private void brn_OK_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Pop_Check_Recipt());
        }
    }
}
