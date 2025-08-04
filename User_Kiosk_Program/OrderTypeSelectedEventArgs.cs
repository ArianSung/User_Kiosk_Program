using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public class OrderTypeSelectedEventArgs : EventArgs
    {
        public OrderType SelectedOrderType { get; }

        public OrderTypeSelectedEventArgs(OrderType selectedOrderType)
        {
            SelectedOrderType = selectedOrderType;
        }
    }
}
