using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Select_Stage : UserControl
    {


        public Page_Select_Stage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        // MainControl이 호출할 공개 메서드
        public void SetBannerImage(Image bannerImage)
        {
            if (bannerImage != null)
            {
                // 이미 완성된 이미지를 받아서 바로 표시
                pb_WebBanner.Image = bannerImage;
            }
            else
            {
                // 이미지를 받아오지 못한 경우 처리
                pb_WebBanner.BackColor = Color.DarkGray;
            }
        }


    }
}
