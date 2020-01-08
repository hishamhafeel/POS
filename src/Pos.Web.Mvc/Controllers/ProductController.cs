using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Pos.Products;
using Pos.Web.ListModels;

namespace Pos.Web.Mvc.Controllers
{
    public class ProductController : AbpController
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        public JsonResult GetProductById(int productId)
        {
            var result = productAppService.GetAllProducts().FirstOrDefault(i => i.Id == productId);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetAllProducts()
        {
            var productList = new List<ProductListModel>();
            var result = productAppService.GetAllProducts().ToList();

            foreach (var item in result)
            {
                productList.Add(new ProductListModel { Value = item.Id, Text = item.ProductName });
            }
            return Json(productList);
        }
    }
}