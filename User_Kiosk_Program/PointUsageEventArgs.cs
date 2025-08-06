using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class PointUsageEventArgs : EventArgs
    {
        public int PointsToUse { get; } // decimal -> int
        public PointUsageEventArgs(int points) // decimal -> int
        {
            PointsToUse = points;
        }
    }
}
