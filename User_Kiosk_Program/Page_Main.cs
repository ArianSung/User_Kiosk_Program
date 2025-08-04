using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace User_Kiosk_Program
{
    public partial class Page_Main : UserControl
    {
        public Page_Main()
        {
            InitializeComponent();
        }

        // 파라미터에 long orderId 추가
        public void InitializePage(OrderType orderType, long orderId)
        {
            string orderTypeText = (orderType == OrderType.DineIn) ? "매장" : "포장";

            // 디자이너에 lbl_OrderInfo 라는 이름의 Label이 있어야 합니다.
            //lbl_OrderInfo.Text = $"주문번호: {orderId} ({orderTypeText}) 주문을 시작합니다.";
        }

    }
}