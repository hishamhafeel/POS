using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pos.Orders.Dto
{
    public class CreateOrderItemInput
    {
        public int Id { get; set; }

        [Range(maximum: 10, minimum: 0)]
        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }

        public decimal UnitPrice { get; set; }

        public int SelectedProductId { get; set; }

        public ProductDto Product { get; set; }

    }
}
