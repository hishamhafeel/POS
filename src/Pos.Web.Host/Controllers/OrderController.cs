using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Controllers;
using Pos.Orders;
using Pos.Orders.Dto;
using Pos.Web.Host.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pos.Web.Host.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrderController : PosControllerBase
    {
        private readonly IOrderAppService orderAppService;
        private readonly IObjectMapper mapper;
        private readonly Products.IProductAppService productAppService;

        public OrderController(IOrderAppService orderAppService, IObjectMapper mapper, Products.IProductAppService productAppService)
        {
            this.orderAppService = orderAppService;
            this.mapper = mapper;
            this.productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var ordersList = orderAppService.GetOrders().OrderByDescending(r => r.Id).ToList();
                return Ok(ordersList);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
           
        }

        [HttpGet, Route("OrderItem/{orderItemId}")]
        public IActionResult GetOrderItemById(int orderItemId)
        {
            try
            {
                var orderItem = orderAppService.GetOrderItems().Where(w => w.Id == orderItemId);
                return Ok(orderItem);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }

        [HttpDelete, Route("Delete/{orderItemId}")]
        public IActionResult Delete(int orderItemId)
        {
            try
            {
                if (orderItemId != 0)
                {
                    orderAppService.Delete(orderItemId);

                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Index", "Order")
                    });

                }
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    success = false,
                    errors = new { ex.Message }
                });
            }

            return NotFound();
        }


        [HttpPost, Route("Create")]
        public IActionResult Create([FromBody]CreateOrderViewModel createOrderViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedInput = mapper.Map<CreateOrderInput>(createOrderViewModel);
                    //create new order 
                    orderAppService.Create(mappedInput);

                    return Json(new
                    {
                        success = true,
                        redirectUrl = Url.Action("Index", "Order")
                    });

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errors = new { ex.Message }
                });
            }

            return NotFound();
        }

        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody]UpdateOrderItemViewModel updateOrderItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = productAppService.GetAllProducts().FirstOrDefault(r => r.Id == updateOrderItem.ProductId);
                    updateOrderItem.Product = product;

                    var updatedOrder = orderAppService.Update(mapper.Map<UpdateOrderInput>(updateOrderItem));

                   
                    return Ok(updatedOrder);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return NotFound();
        }
    }
}
