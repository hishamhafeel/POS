using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pos.Customers;
using Pos.Order;
using Pos.Orders.Dto;
using Pos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IMapper mapper;
        private readonly ProductAppService productAppService;
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWorkManager unitOfWorkManager;

        public OrderAppService(IRepository<Order> orderRepository, IMapper mapper, ProductAppService productAppService, IRepository<OrderItem> orderItemRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.productAppService = productAppService;
            this.orderItemRepository = orderItemRepository;
            this.unitOfWorkManager = unitOfWorkManager;
        }

        //Get all orders
        public List<OrderDto> GetOrders()
        {
            var orders = orderRepository.GetAll().Include(x => x.OrderItems).ThenInclude(o => o.Product).ToList();

            return mapper.Map<List<OrderDto>>(orders);
        }

        //Get all orders items
        public List<OrderItemDto> GetOrderItems()
        {
            var orderItems = orderItemRepository.GetAll().Include(i => i.Order).Include(p => p.Product).ToList();
            return mapper.Map<List<OrderItemDto>>(orderItems);
        }

        //Add order
        [ApiExplorerSettings(IgnoreApi = true)]
        public OrderDto Create(CreateOrderInput input)
        {
            if (input == null)
            {
                throw new OrderNotFoundException();
            }
            var orderItemList = new List<OrderItemDto>();
            foreach (var item in input.OrderItems)
            {
                var product = productAppService.GetAllProducts().FirstOrDefault(i => i.Id == item.SelectedProductId);
                item.UnitPrice = product.ProductUnitPrice;
                item.SubTotal = product.ProductUnitPrice * item.Quantity;
                item.Product = product;
                orderItemList.Add(mapper.Map<OrderItemDto>(item));
            }

            using (var unitOfWork = unitOfWorkManager.Begin())
            {
                try
                {
                    //Create order
                    var model = new Order(input.OrderTotal, input.CustomerId, mapper.Map<List<OrderItem>>(orderItemList));
                    orderRepository.Insert(model);
                    //Update the qty in stock
                    productAppService.UpdateProductQuantityInStock(orderItemList);

                    unitOfWork.Complete();
                    return mapper.Map<OrderDto>(model);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //Update order item
        [ApiExplorerSettings(IgnoreApi = true)]
        public OrderDto Update(UpdateOrderInput input)
        {
            var existingOrderItem = orderItemRepository.GetAll().AsNoTracking().Include(i => i.Order).FirstOrDefault(f => f.Id == input.Id);
            var mappedInput = mapper.Map<OrderItemDto>(input);


            //Validate the orderItem
            if (input == null)
            {
                throw new OrderItemNotFoundException();

            }
            else if (input.Quantity == existingOrderItem.Quantity)
            {
                throw new SameQuantityUpdateException();
            }

            using (var unitOfWork = unitOfWorkManager.Begin())
            {
                try
                {
                    //Update qty in stock
                    var orderItems = new List<OrderItemDto> { mappedInput };
                    productAppService.UpdateProductQuantityInStock(orderItems);

                    //update order
                    var subTotal = existingOrderItem.UnitPrice * input.Quantity;
                    existingOrderItem.Order.SetOrderTotal(existingOrderItem.Order.OrderTotal, existingOrderItem.SubTotal, subTotal);
                    existingOrderItem.SetSubTotal(subTotal);
                    existingOrderItem.SetQuantity(input.Quantity);

                    orderItemRepository.Update(existingOrderItem);
                    orderRepository.Update(existingOrderItem.Order);

                    unitOfWork.Complete();
                    return mapper.Map<OrderDto>(existingOrderItem.Order);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //Delete order item 
        [ApiExplorerSettings(IgnoreApi = true)]
        public void Delete(int id)
        {
            var existingOrderItem = orderItemRepository.GetAll().AsNoTracking()
                                                                .Include(i => i.Order)
                                                                .Include(a => a.Product)
                                                                .FirstOrDefault(f => f.Id == id);
            if (existingOrderItem == null)
            {
                throw new OrderItemNotFoundException();
            }

            using (var unitOfWork = unitOfWorkManager.Begin())
            {
                try
                {
                    //Remove order item from order
                    existingOrderItem.Order.OrderItems.Remove(existingOrderItem);
                    existingOrderItem.Order.SetOrderTotal(existingOrderItem.Order.OrderTotal, existingOrderItem.SubTotal, 0);
                    orderRepository.Update(mapper.Map<Order>(existingOrderItem.Order));
                    //Delete order item
                    orderItemRepository.Delete(existingOrderItem);
                    //update quantity in stock of deleted product
                    var orderItems = new List<OrderItemDto> { mapper.Map<OrderItemDto>(existingOrderItem) };
                    productAppService.UpdateProductQuantityInStock(orderItems);
                    unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<OrderDto> GetOrdersByCustomer(int id)
        {
            var orderItems = orderRepository.GetAll().Include(i => i.OrderItems).Where(w => w.CustomerId == id).ToList();
            return mapper.Map<List<OrderDto>>(orderItems);
        }
    }
}
