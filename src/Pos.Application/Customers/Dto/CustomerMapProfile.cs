using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customers.Dto
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }

    }
}
