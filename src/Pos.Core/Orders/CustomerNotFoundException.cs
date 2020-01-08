using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() : base("Customer was not found. Please choose a customer.")
        {

        }
    }
}
