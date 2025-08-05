using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class PointUsageEventArgs : EventArgs
    {
        public decimal PointsToUse { get; }

        public PointUsageEventArgs(decimal points)
        {
            PointsToUse = points;
        }
    }
}
