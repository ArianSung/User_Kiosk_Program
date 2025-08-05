using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace User_Kiosk_Program
{
    public partial class Pop_Point : UserControl
    {
        private int pointsToAdd = 500; // 💡 클래스 전체에서 공유

        string connStr = "Server=192.168.0.81;Database=kiosk_project;Uid=kiosk_user;Pwd=123456;";

        public Pop_Point()
        {
            InitializeComponent();

            lb_Point_Save.Text = $"{pointsToAdd:N0}P가 적립됩니다.\n적립하시겠습니까?";
            //ShowUserControl(new Pop_Check_Point());
            pn_Error.Visible = false;
            pn_Existing.Visible = false;
            pn_New_Member.Visible = false;
        }

        public void ShowUserControl(UserControl control)
        {
            // 1. pn_Main 패널에 있던 기존 컨트롤들을 모두 지웁니다.
            pn_Pop_Point.Controls.Clear();

            // 2. 새로 받은 컨트롤(control)이 패널을 꽉 채우도록 설정합니다.
            control.Dock = DockStyle.Fill;

            // 3. pn_Main 패널에 새 컨트롤을 추가해서 보여줍니다.
            pn_Pop_Point.Controls.Add(control);

            //lb_Point_Save.Text = $"{pointsToAdd:N0}P가 적립됩니다. 적립하시겠습니까?";
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
        private void btn_C_Click_1(object sender, EventArgs e)
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

        private void btn_Cacel_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Pop_Check_Point());
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            // 패널 숨기기 초기화
            pn_Error.Visible = false;
            pn_Existing.Visible = false;
            pn_New_Member.Visible = false;

            string phoneNumber = textBox_Phone.Text.Trim();

            // 1. 양식 검사
            if (string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^010\d{8}$"))
            {
                pn_Error.Visible = true;
                pn_Error.BringToFront();
                CenterPanel(pn_Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string checkQuery = "SELECT point FROM members WHERE phone_number = @phone";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@phone", phoneNumber);

                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // ✅ 기존 회원
                        int currentPoint = Convert.ToInt32(result);
                        int newPoint = currentPoint + pointsToAdd;

                        string updateQuery = "UPDATE members SET point = @point WHERE phone_number = @phone";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@point", newPoint);
                        updateCmd.Parameters.AddWithValue("@phone", phoneNumber);
                        updateCmd.ExecuteNonQuery();

                        // 패널 표시
                        pn_Existing.Visible = true;
                        pn_Existing.BringToFront();
                        lb_Existing.Text = $"{pointsToAdd:N0}P 적립 완료!";
                        CenterPanel(pn_Existing);
                    }
                    else
                    {
                        // ✅ 신규 회원
                        string insertQuery = "INSERT INTO members (phone_number, point) VALUES (@phone, @point)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@phone", phoneNumber);
                        insertCmd.Parameters.AddWithValue("@point", pointsToAdd);
                        insertCmd.ExecuteNonQuery();

                        pn_New_Member.Visible = true;
                        pn_New_Member.BringToFront();
                        lb_New_Member.Text = $"신규 가입 완료!\n{pointsToAdd:N0}P가 적립되었습니다.";
                        CenterPanel(pn_New_Member);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터베이스 오류: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)//신규
        {
            pn_New_Member.Visible = false;
            ShowUserControl(new Pop_Check_Point());
        }

        private void button4_Click(object sender, EventArgs e)//에러
        {
            pn_Error.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)//적립
        {
            pn_Existing.Visible = false;
            ShowUserControl(new Pop_Check_Point());
        }

        private void Pop_Point_Load(object sender, EventArgs e)
        {
            CenterPanel(pn_Existing);
            CenterPanel(pn_New_Member);
            CenterPanel(pn_Error);
        }
        private void UserControl_Point_Resize(object sender, EventArgs e)
        {
            CenterPanel(pn_Existing);
            CenterPanel(pn_New_Member);
            CenterPanel(pn_Error);
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
    }
}

         
