using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Web.Host.ViewModel
{
    public class CreateOrderItemViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }

        public decimal UnitPrice { get; set; }

        public int SelectedProductId { get; set; }

    }
}
