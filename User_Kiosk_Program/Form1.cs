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
            // Form1�� �ִ� pn_Main �г��� ���
            pn_Main.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pn_Main.Controls.Add(control);

            CenterControl(control);
        }

        public void CenterControl(Control control)
        {
            // ��Ʈ���� �� ũ�⿡ ���� �������� �ʵ��� Anchor �Ӽ� ����
            control.Anchor = AnchorStyles.None;

            // ��Ʈ���� ��ġ ���
            int x = (this.ClientSize.Width - control.Width) / 2;
            int y = (this.ClientSize.Height - control.Height) / 2;

            // ���� ��ġ�� ��Ʈ�� �̵�
            control.Location = new Point(x, y);
        }
    }
}
