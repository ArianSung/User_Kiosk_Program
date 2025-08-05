using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using static User_Kiosk_Program.Pop_Use_Point;

namespace User_Kiosk_Program
{
    public partial class Pop_Check_Recipt : UserControl
    {
        public Pop_Check_Recipt()
        {
            InitializeComponent();
        }

        public void ShowUserControl(UserControl control)
        {
            // 기존 컨트롤 제거
            pn_Pop_Check_Recipt.Controls.Clear();

            // 새 컨트롤 Dock 설정 후 추가
            control.Dock = DockStyle.Fill;
            pn_Pop_Check_Recipt.Controls.Add(control);
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            int orderNumber = GetNextOrderNumber();
          
            Form_Printf_Recipt_No noForm = new Form_Printf_Recipt_No(orderNumber);
            noForm.Show();
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            int orderNumber = GetNextOrderNumber();
            int usedPoints = SessionInfo.UsedPoint;

            Form_Print_Recipt_Yes form = new Form_Print_Recipt_Yes(orderNumber, usedPoints);
            form.Show();
        }

        private int GetNextOrderNumber()
        {
            int orderNumber = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=192.168.0.81;Database=kiosk_project;Uid=kiosk_user;Pwd=123456;"))
                {
                    conn.Open();

                    // 1. 현재 주문번호 가져오기
                    string selectQuery = "SELECT last_order_number FROM order_counter LIMIT 1";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    object result = selectCmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out orderNumber))
                    {
                        orderNumber += 1;

                        // 2. 증가된 주문번호를 다시 DB에 저장
                        string updateQuery = "UPDATE order_counter SET last_order_number = @orderNumber";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // 테이블에 데이터가 없을 경우 (최초 실행 시)
                        orderNumber = 1;
                        string insertQuery = "INSERT INTO order_counter (last_order_number) VALUES (@orderNumber)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("주문번호 생성 오류: " + ex.Message);
            }

            return orderNumber;
        }
    }
}
