using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Web.Models.Order
{
    public class OrderItemsModel
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductSubTotal { get; set; }
    }
}
