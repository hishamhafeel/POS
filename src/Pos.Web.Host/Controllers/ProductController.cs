using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Controllers;
using Pos.Products;

namespace Pos.Web.Host.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : PosControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet("{selectedProductId}")]
        public ActionResult GetProductById(int selectedProductId)
        {
            try
            {
                var result = productAppService.GetAllProducts().FirstOrDefault(i => i.Id == selectedProductId);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }
    }
}