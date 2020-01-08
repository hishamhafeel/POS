using Microsoft.AspNetCore.Antiforgery;
using Pos.Controllers;

namespace Pos.Web.Host.Controllers
{
    public class AntiForgeryController : PosControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
