using MySql.Data.MySqlClient;
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
    public partial class Pop_Use_Point : UserControl
    {
        public Pop_Use_Point(string phoneNumber, int totalPoints)
        {
            InitializeComponent();

            pn_Warning.Visible = false;

            _phoneNumber = phoneNumber;
            _totalPoints = totalPoints;
            lb_Total_Point.Text = $"보유 포인트: {_totalPoints:N0}P";
            lb_Balance_Point.Text = $"사용 후 남은 포인트: {_totalPoints:N0}P";
            btn_Confirm.Enabled = false;
        }

        public Pop_Use_Point(int pointUsed)
        {
            InitializeComponent();

            _pointUsed = pointUsed;
        }
        private readonly int _pointUsed;

        private readonly string _phoneNumber;
        private readonly int _totalPoints;

        public void ShowUserControl(UserControl control)
        {
            // 1. pn_Main 패널에 있던 기존 컨트롤들을 모두 지웁니다.
            pn_Pop_Use_Point.Controls.Clear();

            // 2. 새로 받은 컨트롤(control)이 패널을 꽉 채우도록 설정합니다.
            control.Dock = DockStyle.Fill;

            // 3. pn_Main 패널에 새 컨트롤을 추가해서 보여줍니다.
            pn_Pop_Use_Point.Controls.Add(control);
        }

        public static class SessionInfo
        {
            public static int UsedPoint { get; set; }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text += "0";
        }

        private void btn_Use_AllPoint_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text = _totalPoints.ToString();
        }

        private void btn_Backspace_Click(object sender, EventArgs e)
        {
            if (textBox_Use_Point.Text.Length > 0)
            {
                // 현재 텍스트에서 마지막 한 글자를 제외하고 다시 할당
                textBox_Use_Point.Text = textBox_Use_Point.Text.Remove(textBox_Use_Point.Text.Length - 1);
            }
        }

        private void btn_Cacel_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Pop_Check_Recipt());
        }

        private async void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_Use_Point.Text, out int usePoints))
            {
                ShowWarning("포인트를 입력해주세요.");
                textBox_Use_Point.Text = _totalPoints.ToString();
                return;
            }

            if (usePoints <= 0)
            {
                ShowWarning("포인트를 입력해주세요.");
                textBox_Use_Point.Text = "";
                return;
            }

            if (usePoints < 500)
            {
                ShowWarning("500P 이상부터 사용할 수 있습니다.");
                textBox_Use_Point.Text = _totalPoints.ToString();
                return;
            }

            if (usePoints > _totalPoints)
            {
                ShowWarning("보유 포인트를 초과할 수 없습니다.");
                textBox_Use_Point.Text = "";
                return;
            }

            int newTotalPoints = _totalPoints - usePoints;

            string connStr = "Server=192.168.0.81;Database=kiosk_project;Uid=kiosk_user;Pwd=123456;";
            string updateQuery = "UPDATE members SET point = @point WHERE phone_number = @phoneNumber";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@point", newTotalPoints);
                        cmd.Parameters.AddWithValue("@phoneNumber", _phoneNumber);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            SessionInfo.UsedPoint = usePoints;
                            ShowUserControl(new Pop_Use_Point_OK());
                        }
                        else
                        {
                            ShowWarning("포인트 업데이트에 실패했습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowWarning("데이터베이스 오류: " + ex.Message);
            }
        }

        private void ShowWarning(string message)
        {
            lblWarningMessage.Text = message;
            pn_Warning.Visible = true;
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            textBox_Use_Point.Text = string.Empty;
        }

        private void textBox_Use_Point_TextChanged(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox_Use_Point.Text, out int pointUsed))
                pointUsed = 0;

            int balancePoints = _totalPoints - pointUsed;
            lb_Balance_Point.Text = $"사용 후 남은 포인트: {balancePoints:N0}P";

            btn_Confirm.Enabled = pointUsed > 0;

            lb_Warn.Visible = false;
        }

        private void Pop_Use_Point_Load(object sender, EventArgs e)
        {
            CenterPanel(pn_Warning);
            // 클래스 공용 변수를 사용하여 레이블 텍스트를 설정합니다.
            lb_Total_Point.Text = $"보유 포인트 : {_totalPoints:N0}P";
            lb_Balance_Point.Text = $"사용 후 남은 포인트 : {_totalPoints:N0}P";
            btn_Confirm.Enabled = false;
        }

        private void UserControl_Point_Resize(object sender, EventArgs e)
        {
            CenterPanel(pn_Warning);
        }
        private void CenterPanel(Control panel)
        {
            // 부모 컨테이너의 중앙에 위치하도록 설정
            if (panel.Parent != null)
            {
                int x = (panel.Parent.Width - panel.Width) / 2;
                int y = (panel.Parent.Height - panel.Height) / 2;
                panel.Location = new Point(x, y);
            }
        }

        private void btnWarningOK_Click(object sender, EventArgs e)
        {
            pn_Warning.Visible = false;
        }
    }
}
