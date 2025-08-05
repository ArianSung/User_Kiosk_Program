namespace User_Kiosk_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ShowUserControl(new Pop_Point());
        }
        public void ShowUserControl(UserControl control)
        {
            // Form1에 있는 pn_Main 패널을 사용
            pn_Main.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pn_Main.Controls.Add(control);

            CenterControl(control);
        }

        public void CenterControl(Control control)
        {
            // 컨트롤이 폼 크기에 따라 움직이지 않도록 Anchor 속성 해제
            control.Anchor = AnchorStyles.None;

            // 컨트롤의 위치 계산
            int x = (this.ClientSize.Width - control.Width) / 2;
            int y = (this.ClientSize.Height - control.Height) / 2;

            // 계산된 위치로 컨트롤 이동
            control.Location = new Point(x, y);
        }
    }
}
