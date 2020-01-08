using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class OrderTotalInvalidException : Exception
    {
        public OrderTotalInvalidException() : base("Order Total is invalid. Please enter a valid value (greater than 0).")
        {

        }
    }
}
