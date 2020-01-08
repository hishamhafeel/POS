using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class OrderItemNotFoundException : Exception
    {
        public OrderItemNotFoundException() : base("Order Item that has been requested is not found!")
        {

        }
    }
}
