using System;
using System.Collections.Generic;
using System.Linq;
using Abp.AspNetCore.Mvc.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pos.Customers;
using Pos.Orders;
using Pos.Orders.Dto;
using Pos.Products;
using Pos.Web.ListModels;
using Pos.Web.Models.Order;

namespace Pos.Web.Controllers
{
    public class OrderController : AbpController
    {
        private readonly ICustomerAppService customerAppService;
        private readonly IOrderAppService orderAppService;
        private readonly IProductAppService productAppService;
        private readonly IMapper mapper;

        public OrderController(ICustomerAppService customerAppService, IOrderAppService orderAppService,
                                    IProductAppService productAppService, IMapper mapper)
        {
            this.customerAppService = customerAppService;
            this.orderAppService = orderAppService;
            this.productAppService = productAppService;
            this.mapper = mapper;
        }




        //Home View with customer drop down
        [HttpGet]
        public IActionResult Index()
        {
            var customerNameResult = customerAppService.GetAllCustomers()
                .Select(s => new CustomerListModel { Text = s.CustomerName, Value = s.Id }).ToList();

            PlaceOrderViewModel model = new PlaceOrderViewModel
            {
                CustomerNameList = new List<SelectListItem>()
            };

            foreach (var item in customerNameResult)
            {
                model.CustomerNameList.Add(new SelectListItem { Text = item.Text, Value = item.Value.ToString() });
            }

            model.OrderDate = DateTime.Now;

            return View(model);
        }


        //Place order with order items before saving 
        [HttpGet]
        public IActionResult PlaceOrder(PlaceOrderViewModel placeOrderModel)
        {
            if (ModelState.IsValid)
            {
                //product drop down for selecting product
                var productNameResult = productAppService.GetAllProducts()
                    .Select(s => new ProductListModel { Text = s.ProductName, Value = s.Id }).ToList(); ;
                var customer = customerAppService.
                    GetAllCustomers().FirstOrDefault(i => i.Id == placeOrderModel.SelectedCustomerId);

                OrderViewModel model = new OrderViewModel()
                {
                    ProductNameList = new List<SelectListItem>(),
                    OrderDate = placeOrderModel.OrderDate,
                    CustomerId = placeOrderModel.SelectedCustomerId,
                    Customer = customer
                };

                foreach (var item in productNameResult)
                {
                    model.ProductNameList.
                        Add(new SelectListItem
                        {
                            Text = item.Text,
                            Value = item.Value.ToString()
                        });
                }

                return View(model);
            }

            return NotFound();

        }

        //Get order for a given customer
        [HttpGet]
        public JsonResult GetOrdersByCustomer(int customerId)
        {
            var ordersList = orderAppService.GetOrders().Where(i => i.CustomerId == customerId);
            return Json(ordersList);
        }

        //Get all orders
        [HttpGet]
        public JsonResult GetAllOrders()
        {
            var ordersList = orderAppService.GetOrders().OrderByDescending(r => r.Id);
            return Json(ordersList);
        }

        //Get order item details for given order item ID
        [HttpGet]
        public IActionResult ViewOrderItem(int orderItemId)
        {
            var orderItem = orderAppService.GetOrderItems().FirstOrDefault(r => r.Id == orderItemId);
            if(orderItem == null)
            {
                throw new OrderItemNotFoundException();
            }

            var model = new UpdateOrderItemViewModel()
            {
                Id = orderItemId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                SubTotal = orderItem.SubTotal,
                Order = orderItem.Order,
                ProductId = orderItem.Product.Id
            };
            return View(model);
        }

        //View order details 
        [HttpGet]
        public IActionResult ViewDetails(int orderId)
        {
            if (orderId != 0)
            {
                var order = orderAppService.GetOrders().FirstOrDefault(i => i.Id == orderId);
                var customer = customerAppService.GetAllCustomers().FirstOrDefault(i =>i.Id == order.CustomerId);

                var model = new GetOrderViewModel()
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    OrderTotal = order.OrderTotal,
                    OrderItems = mapper.Map<List<OrderItemDto>>(order.OrderItems),
                    CustomerId = order.CustomerId,
                    CustomerName = customer.CustomerName

                };

                return View(model);
            }

            return NotFound();
        }


        //Create order with order items
        public IActionResult AddOrder([FromBody]CreateOrderViewModel createOrderViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //create new order 
                    orderAppService.Create(mapper.Map<CreateOrderInput>(createOrderViewModel));

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


        //Update Order Item for given order item ID
        [HttpPost]
        public IActionResult UpdateOrderItem(UpdateOrderItemViewModel updateOrderItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = productAppService.GetAllProducts().FirstOrDefault(r => r.Id == updateOrderItem.ProductId);
                    updateOrderItem.Product = product;

                    orderAppService.Update(mapper.Map<UpdateOrderInput>(updateOrderItem));

                    var id = updateOrderItem.Order.Id;
                    return RedirectToAction("ViewDetails", "Order", new { orderId = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return NotFound();
        }


        //Delete order item for a given order item ID
        [HttpPost]
        public IActionResult DeleteOrderItem(int id)
        {
            try
            {
                if (id != 0)
                {
                    orderAppService.Delete(id);

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


    }
}