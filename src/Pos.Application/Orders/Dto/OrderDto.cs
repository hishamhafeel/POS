using Pos.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductSubTotal { get; set; }
    }
}
