using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Products.Dto
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
