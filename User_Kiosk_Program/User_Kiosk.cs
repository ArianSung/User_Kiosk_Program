namespace User_Kiosk_Program
{
    public partial class User_Kiosk : Form
    {
        public User_Kiosk()
        {
            InitializeComponent();
        }

        private void User_Kiosk_Load(object sender, EventArgs e)
        {
            // DatabaseManager�� ����Ͽ� ������ �׽�Ʈ�մϴ�.
            bool isConnected = DatabaseManager.Instance.TestConnection();

            if (!isConnected)
            {
                // �����ͺ��̽� ���ῡ �����ϸ� ���α׷��� �����ϴ� ���� �������Դϴ�.
                Application.Exit();
            }
        }
    }
}
