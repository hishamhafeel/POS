using Abp.Application.Services;
using Pos.Orders.Dto;
using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Products
{
    public interface IProductAppService : IApplicationService
    {
        List<ProductDto> GetAllProducts();
        void UpdateProductQuantityInStock(List<OrderItemDto> orderItems);
    }
}
