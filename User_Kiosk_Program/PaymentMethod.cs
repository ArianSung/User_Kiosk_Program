// PaymentMethod.cs
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class PaymentMethod
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public string PaymentImageUrl { get; set; }
        public Image PaymentImage { get; set; } // URL을 통해 로드된 최종 이미지를 저장할 속성
    }
}
