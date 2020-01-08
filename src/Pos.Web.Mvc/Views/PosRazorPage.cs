using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Pos.Web.Views
{
    public abstract class PosRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PosRazorPage()
        {
            LocalizationSourceName = PosConsts.LocalizationSourceName;
        }
    }
}
