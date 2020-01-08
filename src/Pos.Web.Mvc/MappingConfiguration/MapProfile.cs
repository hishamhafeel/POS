using AutoMapper;
using Pos.Orders.Dto;
using Pos.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Web.MappingConfiguration
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<CreateOrderInput, CreateOrderViewModel>().ReverseMap();
            CreateMap<OrderItemDto, CreateOrderItemViewModel>().ReverseMap();
            CreateMap<CreateOrderItemInput, CreateOrderItemViewModel>().ReverseMap();
            CreateMap<UpdateOrderInput, UpdateOrderItemViewModel>().ReverseMap();
            CreateMap<DeleteOrderInput, DeleteOrderViewModel>().ReverseMap();
        }
    }
}
