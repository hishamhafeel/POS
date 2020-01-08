using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Controllers;
using Pos.Customers;
using Pos.Orders;

namespace Pos.Web.Host.Controllers
{
    [Route("api/v1/[controller]")]

    public class CustomerController : PosControllerBase
    {
        private readonly IOrderAppService orderAppService;
        private readonly IMapper mapper;

        public CustomerController(IOrderAppService orderAppService, IMapper mapper)
        {
            this.orderAppService = orderAppService;
            this.mapper = mapper;
        }

        [HttpGet, Route("{customerId}/Order")]
        public IActionResult GetOrdersByCustomer(int customerId)
        {
            try
            {
                var ordersList = orderAppService.GetOrdersByCustomer(customerId).ToList();
                return Ok(ordersList);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }
    }
}