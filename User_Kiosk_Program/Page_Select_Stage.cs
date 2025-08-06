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
        public event EventHandler<OrderTypeSelectedEventArgs> OrderTypeSelected;
        public event EventHandler UserActivity;

        public Page_Select_Stage()
        {
            InitializeComponent();
            this.MouseMove += OnUserActivity;
            pb_WebBanner.MouseMove += OnUserActivity;
            btn_Store.MouseMove += OnUserActivity;
            btn_Pickup.MouseMove += OnUserActivity;
            this.DoubleBuffered = true;

        }

        // MainControl이 호출할 공개 메서드
        public void SetBannerImage(Image bannerImage)
        {
            if (bannerImage != null)
            {
                // ImageHelper를 사용하여 자신의 PictureBox 크기에 맞게 리사이즈
                pb_WebBanner.Image = ImageHelper.ResizeImage(bannerImage, pb_WebBanner.Size);
                bannerImage.Dispose(); // 원본 이미지는 더 이상 필요 없으므로 리소스 해제
            }
            else
            {
                pb_WebBanner.BackColor = Color.DarkGray;
            }
        }

        private void btn_Store_Click(object sender, EventArgs e)
        {
            // OrderType.DineIn 정보를 담아 신호를 보냄
            OrderTypeSelected?.Invoke(this, new OrderTypeSelectedEventArgs(OrderType.DineIn));
        }

        private void btn_Pickup_Click(object sender, EventArgs e)
        {
            // OrderType.Takeout 정보를 담아 신호를 보냄
            OrderTypeSelected?.Invoke(this, new OrderTypeSelectedEventArgs(OrderType.Takeout));
        }
        public void SetTheme(Color mainColor, Color panelColor)
        {

            this.BackColor = panelColor;
        }

        private void OnUserActivity(object sender, MouseEventArgs e)
        {
            UserActivity?.Invoke(this, EventArgs.Empty);
        }
    }
}
