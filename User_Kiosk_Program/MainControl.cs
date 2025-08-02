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

 

        // Default page
        private void ShowDefaultPage()
        {
            this.Controls.Clear();
            Page_Default defaultPage = new Page_Default();

            defaultPage.ScreenClicked += OnDefaultPageScreenClicked;

            defaultPage.Dock = DockStyle.Fill;
            this.Controls.Add(defaultPage);
        }

        private void OnDefaultPageScreenClicked(object? sender, EventArgs e)
        {
            // 이벤트 구독을 해제하여 메모리 누수를 방지할 수 있습니다.
            if (sender is Page_Default defaultPage)
            {
                defaultPage.ScreenClicked -= OnDefaultPageScreenClicked;
            }

            ShowSelectStagePage();
        }

        // Select Page
        private void ShowSelectStagePage()
        {
            this.Controls.Clear();
            Page_Select_Stage selectStagePage = new Page_Select_Stage();
            selectStagePage.Dock = DockStyle.Fill;
            this.Controls.Add(selectStagePage);
        }
    }
}
