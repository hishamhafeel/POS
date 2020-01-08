using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class OrderTotalExceededException : Exception
    {
        public OrderTotalExceededException() : base("Order Total has exceeded. Order Total must be below LKR 10,000")
        {

        }
    }
}
