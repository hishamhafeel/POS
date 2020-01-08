using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Products.Dto
{
    public class NoItemInStockException : Exception
    {
        public NoItemInStockException() : base("There are no items in stock.")
        {

        }
    }
}
