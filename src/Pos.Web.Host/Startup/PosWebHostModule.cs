using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pos.Configuration;
using Abp.AspNetCore.Configuration;
using Abp.Application.Services;
using Abp.WebApi.Controllers.Dynamic.Builders;
using System.Reflection;
using Abp.AutoMapper;
using Pos.Orders.Dto;
using Pos.Web.Host.ViewModel;

namespace Pos.Web.Host.Startup
{
    [DependsOn(
       typeof(PosWebCoreModule))]
    public class PosWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PosWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(PosApplicationModule).Assembly, moduleName: "pos", useConventionalHttpVerbs: true);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateOrderInput, CreateOrderViewModel>().ReverseMap();
                config.CreateMap<CreateOrderItemInput, CreateOrderItemViewModel>().ReverseMap();
                config.CreateMap<UpdateOrderInput, UpdateOrderItemViewModel>().ReverseMap();
            });
        }

 

            

        public override void Initialize()
        {
            var thisAssembly = typeof(PosWebHostModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
           
        }
    }
}
