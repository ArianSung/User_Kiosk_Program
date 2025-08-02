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
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
            this.Load += MainControl_Load;
        }

        private void MainControl_Load(object? sender, EventArgs e)
        {
            ShowDefaultPage();
        }

        private void ShowDefaultPage()
        {
            this.Controls.Clear();
            Page_Default defaultPage = new Page_Default();
            defaultPage.Dock = DockStyle.Fill;
            this.Controls.Add(defaultPage);
        }
    }
}
