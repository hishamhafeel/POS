using AutoMapper;
using Pos.Customers.Dto;
using Pos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Orders.Dto
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();

            CreateMap<OrderItemDto, CreateOrderItemInput>().ReverseMap();
            CreateMap<OrderItemDto, UpdateOrderInput>().ReverseMap();

            CreateMap<OrderDto, CreateOrderInput>().ReverseMap();
            CreateMap<CreateOrderItemInput, OrderItem>().ReverseMap();
        }
    }
}
