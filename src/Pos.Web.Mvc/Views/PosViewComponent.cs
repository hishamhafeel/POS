using Abp.AspNetCore.Mvc.ViewComponents;

namespace Pos.Web.Views
{
    public abstract class PosViewComponent : AbpViewComponent
    {
        protected PosViewComponent()
        {
            LocalizationSourceName = PosConsts.LocalizationSourceName;
        }
    }
}
