using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class PointUsageEventArgs : EventArgs
    {
        public int PointsToUse { get; }
        public Member Member { get; } // 사용한 회원 정보를 담을 속성 추가

        public PointUsageEventArgs(int points, Member member) // 생성자에 member 추가
        {
            PointsToUse = points;
            Member = member;
        }
    }
}
