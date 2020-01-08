using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class QuantityNotValidException : Exception
    {
        public QuantityNotValidException() : base("Quantity is not valid.")
        {

        }
    }
}
