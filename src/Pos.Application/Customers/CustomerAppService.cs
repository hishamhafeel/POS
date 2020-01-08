using Abp.Domain.Repositories;
using AutoMapper;
using Pos.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Customers
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IMapper mapper;

        public CustomerAppService(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public List<CustomerDto> GetAllCustomers()
        {
            var result =  customerRepository.GetAll().ToList();
            return mapper.Map<List<CustomerDto>>(result);
        }

    }
}
