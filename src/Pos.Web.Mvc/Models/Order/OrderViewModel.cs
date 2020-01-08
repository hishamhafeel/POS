using Microsoft.AspNetCore.Mvc.Rendering;
using Pos.Customers.Dto;
using Pos.Orders.Dto;
using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pos.Web.Models.Order
{
    public class OrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Item Total Price")]
        public decimal OrderTotal { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderFinalTotal { get; set; }

        public CustomerDto Customer { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public List<SelectListItem> CustomerNameList { get; set; }

        [Display(Name = "Product Name")]
        public List<SelectListItem> ProductNameList { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public int SelectedProductId { get; set; }

        public int BuyQuantity { get; set; }

        public string ProductNameInOrderItems { get; set; }

        public ProductDto Product { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
