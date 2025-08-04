using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace User_Kiosk_Program
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal BasePrice { get; set; }
        public string ProductImageUrl { get; set; } // DB에서 가져온 URL
        public Image ProductImage { get; set; }      // URL을 통해 로드 및 리사이징된 최종 이미지
        public List<OptionGroup> OptionGroups { get; set; }

        public Product()
        {
            OptionGroups = new List<OptionGroup>();
        }
    }
}
