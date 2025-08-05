using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Drawing;
//
namespace User_Kiosk_Program
{
    public class DatabaseManager
    {
        private static readonly DatabaseManager instance = new DatabaseManager();
        public static DatabaseManager Instance => instance;
        private readonly string connectionString;

        private DatabaseManager()
        {
            // ▼▼▼▼▼ 사용자 환경에 맞게 이 부분을 수정 ▼▼▼▼▼
            string server = "192.168.0.81";
            string database = "kiosk_project";  // 사용하시는 데이터베이스 이름으로 변경
            string uid = "kiosk_user";
            string password = "123456"; // 자신의 DB 비밀번호로 변경
            // ▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<string> GetAdImageUrls()
        {
            List<string> urls = new List<string>();
            // 이 쿼리는 'advertisements' 테이블이 DB에 존재해야 합니다.
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

        public string GetWebBannerImageUrl(string imageKey)
        {
            string url = null;
            // 이 쿼리는 'webbanner_image' 테이블이 DB에 존재해야 합니다.
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

        public Image GetSystemImage(string imageKey)
        {
            Image image = null;
            string query = "SELECT image_data FROM system_images WHERE image_key = @key";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", imageKey);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(0))
                            {
                                // BLOB 데이터를 byte 배열로 읽어와 MemoryStream을 통해 Image 객체로 변환
                                byte[] imageData = (byte[])reader["image_data"];
                                using (var ms = new MemoryStream(imageData))
                                {
                                    image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"시스템 이미지 로딩 오류: {ex.Message}");
                }
            }
            return image;
        }

        public Color GetSystemColor(string colorKey)
        {
            // 기본 색상을 흰색으로 설정
            Color color = Color.White;
            string colorHex = null;
            string query = "SELECT color_value FROM system_colors WHERE color_key = @key";

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", colorKey);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            colorHex = result.ToString();
                            // ColorTranslator를 사용하여 HEX 코드(#FFFFFF)를 Color 객체로 변환합니다.
                            color = ColorTranslator.FromHtml(colorHex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"시스템 색상 로딩 오류 (Key: {colorKey}): {ex.Message}");
                }
            }
            return color;
        }

        public List<Category> GetCategories()
        {
            var categories = new List<Category>();
            string query = "SELECT category_id, category_name FROM categories ORDER BY category_id ASC";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                CategoryId = reader.GetInt32("category_id"),
                                CategoryName = reader.GetString("category_name")
                            });
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"카테고리 로딩 오류: {ex.Message}"); }
            }
            return categories;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var products = new List<Product>();
            // 쿼리에 'description' 컬럼 추가
            string query = "SELECT product_id, product_name, base_price, description, product_image FROM products WHERE category_id = @category_id";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category_id", categoryId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    ProductId = reader.GetInt32("product_id"),
                                    ProductName = reader.GetString("product_name"),
                                    BasePrice = reader.GetDecimal("base_price"),
                                    // description 값을 ProductDescription 속성에 저장
                                    ProductDescription = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                                    ProductImageUrl = reader.IsDBNull(reader.GetOrdinal("product_image")) ? null : reader.GetString("product_image")
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"상품 로딩 오류: {ex.Message}"); }
            }
            return products;
        }

        public List<OptionGroup> GetOptionsForProduct(int productId)
        {
            var optionGroups = new List<OptionGroup>();
            // 쿼리에 allow_multiple 컬럼 추가
            string groupQuery = "SELECT group_id, group_name, is_required, allow_multiple FROM option_groups WHERE product_id = @product_id ORDER BY display_order";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var groupCmd = new MySqlCommand(groupQuery, conn))
                {
                    groupCmd.Parameters.AddWithValue("@product_id", productId);
                    using (var groupReader = groupCmd.ExecuteReader())
                    {
                        while (groupReader.Read())
                        {
                            var group = new OptionGroup
                            {
                                GroupId = groupReader.GetInt32("group_id"),
                                GroupName = groupReader.GetString("group_name"),
                                IsRequired = groupReader.GetBoolean("is_required"),
                                // allow_multiple 값을 읽어와 속성에 저장
                                AllowMultiple = groupReader.GetBoolean("allow_multiple")
                            };
                            optionGroups.Add(group);
                        }
                    }
                }

                foreach (var group in optionGroups)
                {
                    string optionQuery = "SELECT option_id, option_name, additional_price FROM options WHERE group_id = @group_id ORDER BY display_order";
                    using (var optionCmd = new MySqlCommand(optionQuery, conn))
                    {
                        optionCmd.Parameters.AddWithValue("@group_id", group.GroupId);
                        using (var optionReader = optionCmd.ExecuteReader())
                        {
                            while (optionReader.Read())
                            {
                                group.Options.Add(new Option
                                {
                                    OptionId = optionReader.GetInt32("option_id"),
                                    OptionName = optionReader.GetString("option_name"),
                                    AdditionalPrice = optionReader.GetDecimal("additional_price")
                                });
                            }
                        }
                    }
                }
            }
            return optionGroups;
        }

        public long CreateNewOrder(OrderType orderType)
        {
            string query = "INSERT INTO orders (order_type) VALUES (@order_type); SELECT LAST_INSERT_ID();";
            long newOrderId = -1;
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@order_type", orderType.ToString());
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            newOrderId = Convert.ToInt64(result);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"새 주문 생성 중 오류 발생: {ex.Message}"); }
            }
            return newOrderId;
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            var paymentMethods = new List<PaymentMethod>();
            string query = "SELECT payment_id, payment_name, payment_image FROM payments ORDER BY payment_id ASC";

            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paymentMethods.Add(new PaymentMethod
                            {
                                PaymentId = reader.GetInt32("payment_id"),
                                PaymentName = reader.GetString("payment_name"),
                                PaymentImageUrl = reader.IsDBNull(reader.GetOrdinal("payment_image")) ? "" : reader.GetString("payment_image")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"결제 수단 로딩 오류: {ex.Message}");
                }
            }
            return paymentMethods;
        }

        public Member GetMemberByPhoneNumber(string phoneNumber)
        {
            Member member = null;
            string query = "SELECT Phone_Number, Point FROM members WHERE Phone_Number = @phone";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phoneNumber);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                member = new Member
                                {
                                    PhoneNumber = reader.GetString("Phone_Number"),
                                    Point = reader.GetDecimal("Point")
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 정보 조회 오류: {ex.Message}");
                }
            }
            return member;
        }
    }
}

