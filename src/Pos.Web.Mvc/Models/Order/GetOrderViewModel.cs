using Pos.Orders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pos.Web.Models.Order
{
    public class GetOrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }


        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

    }
}
