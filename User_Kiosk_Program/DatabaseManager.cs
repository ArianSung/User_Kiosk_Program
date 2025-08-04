using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
//
namespace User_Kiosk_Program
{
    public class DatabaseManager
    {
        private static readonly DatabaseManager instance = new DatabaseManager();

        public static DatabaseManager Instance => instance;

        private readonly string connectionString;
        private MySqlConnection connection;

        private DatabaseManager()
        {
            // ▼▼▼▼▼ 사용자 환경에 맞게 이 부분을 수정 ▼▼▼▼▼
            string server = "127.0.0.1"; // MySQL 서버 주소 (로컬이면 127.0.0.1 또는 localhost)
            string database = "kiosk_project";  // 사용할 데이터베이스 이름
            string uid = "root";          // MySQL 사용자 ID
            string password = "123456"; // MySQL 사용자 비밀번호
            // ▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        // Page_Select_Stage Webbnner Image
        public string GetWebBannerImageUrl(string imageKey)
        {
            string url = null;
            string query = "SELECT image_url FROM webbanner_image WHERE image_key = @key LIMIT 1";

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", imageKey);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            url = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"웹 배너 이미지를 불러오는 중 오류 발생: {ex.Message}", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return url;
        }

        // Page_Default Ad_Image
        public List<string> GetAdImageUrls()
        {
            List<string> urls = new List<string>();
            string query = "SELECT image_url FROM advertisements WHERE is_active = TRUE ORDER BY display_order ASC";

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                urls.Add(reader["image_url"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"광고 목록을 불러오는 중 오류가 발생했습니다: {ex.Message}", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return urls;
        }

        public long CreateNewOrder(OrderType orderType)
        {
            string query = "INSERT INTO orders (order_type) VALUES (@order_type); SELECT LAST_INSERT_ID();";
            long newOrderId = -1;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@order_type", orderType.ToString());

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            newOrderId = Convert.ToInt64(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"새 주문 생성 중 오류 발생: {ex.Message}", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return newOrderId;
        }

        public bool TestConnection()
        {
            try
            {
                connection.Open();
                MessageBox.Show("데이터베이스에 성공적으로 연결되었습니다.", "연결 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"데이터베이스 연결에 실패했습니다: \n{ex.Message}", "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

