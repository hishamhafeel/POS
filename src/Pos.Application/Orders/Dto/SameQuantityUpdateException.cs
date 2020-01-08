using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders.Dto
{
    public class SameQuantityUpdateException : Exception
    {
        public SameQuantityUpdateException() : base("You are trying to update with the same quantity as earlier. Please enter different quantity.")
        {

        }
    }
}
