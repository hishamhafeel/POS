using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Pos.Controllers;

namespace Pos.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : PosControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
