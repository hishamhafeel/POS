using Pos.Orders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pos.Web.Models.Order
{
    public class CreateOrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Item Total Price")]
        public decimal OrderTotal { get; set; }

        public List<CreateOrderItemViewModel> OrderItems { get; set; }
    }
}
