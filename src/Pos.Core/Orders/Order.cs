using Abp.Domain.Entities;
using Abp.Timing;
using Pos.Customers;
using Pos.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Orders
{
    public class Order : Entity
    {
        private int customerId;
        private decimal orderTotal;
        private ICollection<OrderItem> orderItems;

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; protected set; }

        public ICollection<OrderItem> OrderItems { get; protected set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal
        {
            get
            {
                return orderTotal;
            }
            protected set
            {
                if (value > 10000)
                {
                    throw new OrderTotalExceededException();
                }
                orderTotal = value;
            }
        }

        public int CustomerId
        {
            get
            {
                return customerId;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new CustomerNotFoundException();
                }
                customerId = value;
            }
        }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; protected set; }

        protected Order()
        {
            OrderItems = new Collection<OrderItem>();
        }

        public Order(decimal orderTotal, int customerId, List<OrderItem> orderItems)
        {
            OrderDate = Clock.Now;
            OrderTotal = orderTotal;
            CustomerId = customerId;
            OrderItems = orderItems;
        }

        public void SetOrderTotal(decimal orderTotal, decimal existingSubTotal, decimal newSubtotal)
        {
            if (orderTotal == 0)
            {
                throw new OrderTotalInvalidException();
            }
            else if (existingSubTotal == 0)
            {
                throw new SubTotalNotValidException();
            }

            OrderTotal -= existingSubTotal;
            OrderTotal += newSubtotal;
        }

    }
}
