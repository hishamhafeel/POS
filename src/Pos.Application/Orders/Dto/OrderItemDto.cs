using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pos.Orders.Dto
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(maximum: 10, minimum: 0)]
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
