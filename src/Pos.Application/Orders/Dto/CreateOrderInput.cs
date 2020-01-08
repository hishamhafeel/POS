using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pos.Orders.Dto
{
    public class CreateOrderInput
    {

        [Required]
        public DateTime OrderDate { get; set; }

        public decimal OrderTotal { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public List<CreateOrderItemInput> OrderItems { get; set; }
    }
}
