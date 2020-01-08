using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders
{
    public class SubTotalNotValidException : Exception
    {
        public SubTotalNotValidException() : base("Sub-total is not valid. Please enter valid sub total which is above 0.")
        {

        }
    }
}
