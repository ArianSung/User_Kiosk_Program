using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class OptionGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool IsRequired { get; set; }
        public bool AllowMultiple { get; set; } // 중복 선택 여부 속성 추가
        public List<Option> Options { get; set; }

        public OptionGroup()
        {
            Options = new List<Option>();
        }
    }
}
