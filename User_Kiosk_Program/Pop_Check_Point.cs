using MySql.Data.MySqlClient;
//
namespace User_Kiosk_Program
{
    public partial class Pop_Check_Point : UserControl
    {
        string connStr = "Server=192.168.0.81;Database=kiosk_project;Uid=kiosk_user;Pwd=123456;";

        private readonly string _phoneNumber;
        private readonly int _totalPoints;

        private int points = 0; // 클래스 필드로 선언

        public Pop_Check_Point()
        {
            InitializeComponent();
        }
        public Pop_Check_Point(string phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            textBox_Phone.Text = _phoneNumber;
            pn_PointWarning.Visible = false;
        }

        public void ShowUserControl(UserControl control)
        {
            // 1. pn_Main 패널에 있던 기존 컨트롤들을 모두 지웁니다.
            pn_Pop_Check_Point.Controls.Clear();

            // 2. 새로 받은 컨트롤(control)이 패널을 꽉 채우도록 설정합니다.
            control.Dock = DockStyle.Fill;

            // 3. pn_Main 패널에 새 컨트롤을 추가해서 보여줍니다.
            pn_Pop_Check_Point.Controls.Add(control);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text += "0";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            textBox_Phone.Text = string.Empty;
        }

        private void btn_Backspace_Click(object sender, EventArgs e)
        {
            if (textBox_Phone.Text.Length > 0)
            {
                // 현재 텍스트에서 마지막 한 글자를 제외하고 다시 할당
                textBox_Phone.Text = textBox_Phone.Text.Remove(textBox_Phone.Text.Length - 1);
            }
        }

        private bool _isChecked = false;      // 상태 추적용
        private string _checkedPhoneNumber;   // 조회된 전화번호 저장
        private int _checkedPoints = 0;       // 조회된 포인트 저장

        private async void btn_Check_Point_Click(object sender, EventArgs e)
        {
            pn_PointWarning.Visible = false;

            if (!_isChecked)
            {
                string phoneNumber = textBox_Phone.Text.Trim();

                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    ShowPointWarning("휴대폰 번호를 입력해주세요.");
                    return;
                }

                if (phoneNumber.Length != 11)
                {
                    ShowPointWarning("휴대폰 번호를 입력해주세요.");
                    return;
                }

                string query = "SELECT Point FROM members WHERE Phone_Number = @Phone";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        await conn.OpenAsync();

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                            object result = await cmd.ExecuteScalarAsync();

                            if (result != null)
                            {
                                _checkedPhoneNumber = phoneNumber;
                                _checkedPoints = Convert.ToInt32(result);
                                lb_Check_Point.Text = $"보유 포인트: {_checkedPoints:N0}P";

                                _isChecked = true;
                                btn_Check_Point.Text = "확인";
                            }
                            else
                            {
                                ShowPointWarning("등록된 회원 정보가 없습니다.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowPointWarning("데이터베이스 오류: " + ex.Message);
                }
            }
            else
            {
                ShowUserControl(new Pop_Use_Point(_checkedPhoneNumber, _checkedPoints));
            }
        }

        private void btn_Cacel_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Pop_Check_Recipt());
        }

        private void btnPointWarningOK_Click(object sender, EventArgs e)
        {
            pn_PointWarning.Visible = false;
        }
        private void ShowPointWarning(string message)
        {
            if (lblPointWarningMessage != null)
            {
                lblPointWarningMessage.Text = message;
                pn_PointWarning.Visible = true;
            }
        }
    }
}
