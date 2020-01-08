using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base("Order that has been requested is not found!")
        {

        }
    }
}
