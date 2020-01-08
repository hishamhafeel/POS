using Abp.Application.Services;
using Pos.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        List<CustomerDto> GetAllCustomers();
    }
}
