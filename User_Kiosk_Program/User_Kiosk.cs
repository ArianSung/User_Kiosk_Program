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
            // DatabaseManager를 사용하여 연결을 테스트합니다.
            bool isConnected = DatabaseManager.Instance.TestConnection();

            if (!isConnected)
            {
                // 데이터베이스 연결에 실패하면 프로그램을 종료하는 것이 안정적입니다.
                Application.Exit();
            }
        }
    }
}
