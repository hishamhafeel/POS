using Abp.Application.Services;
using Pos.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        List<OrderDto> GetOrders();
        List<OrderItemDto> GetOrderItems();
        OrderDto Create(CreateOrderInput input);
        OrderDto Update(UpdateOrderInput input);
        void Delete(int id);
        List<OrderDto> GetOrdersByCustomer(int id);

    }
}
