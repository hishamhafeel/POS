using Abp;
using Abp.Domain.Entities;
using Pos.Orders;
using Pos.Products;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Pos.Order
{
    public class OrderItem : Entity<int>
    {
        
        public decimal UnitPrice { get; protected set; }
        [Required]
        [Range(maximum: 10, minimum: 0)]
        public int Quantity { get; protected set; }
        public decimal SubTotal { get; protected set; }
        public Orders.Order Order { get; protected set; }
        public Product Product { get; protected set; }

        protected OrderItem()
        {

        }

        public OrderItem(decimal unitPrice, int quantity, decimal subTotal)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            SubTotal = subTotal;
        }

        public virtual void SetSubTotal(decimal subTotal)
        {
            if (subTotal == 0)
            {
                throw new SubTotalNotValidException();
            }
            SubTotal = subTotal;
        }

        public void SetQuantity(int qty)
        {
            if (qty == 0)
            {
                throw new QuantityNotValidException();
            }
            Quantity = qty;
        }

    }
}
