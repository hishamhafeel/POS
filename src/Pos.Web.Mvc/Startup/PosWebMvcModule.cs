using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pos.Configuration;
using Abp.AutoMapper;
using Abp.AspNetCore.Configuration;

namespace Pos.Web.Startup
{
    [DependsOn(typeof(PosWebCoreModule))]
    public class PosWebMvcModule : AbpModule
    {
        private const string ModuleName = "pos";
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PosWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PosNavigationProvider>();
            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(PosApplicationModule).Assembly, moduleName: ModuleName, useConventionalHttpVerbs: true);

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            //{
            //    config.CreateMap<CreateOrderInput, User>();

            //});


        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PosWebMvcModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
               // Scan the assembly for classes which inherit from AutoMapper.Profile
               cfg => cfg.AddMaps(thisAssembly)
           );
        }
    }
}
