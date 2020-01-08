using Pos.Orders.Dto;
using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Web.Host.ViewModel
{
    public class UpdateOrderItemViewModel
    {
        [Display(Name = "Order Item ID")]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Sub-Total")]
        public decimal SubTotal { get; set; }

        public OrderDto Order { get; set; }

        public ProductDto Product { get; set; }
    }
}
