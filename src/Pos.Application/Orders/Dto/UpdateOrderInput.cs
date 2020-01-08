using Pos.Customers.Dto;
using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pos.Orders.Dto
{
    public class UpdateOrderInput
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal OrderTotal { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product{ get; set; }
        public int ProductId{ get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
