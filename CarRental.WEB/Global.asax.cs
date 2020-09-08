using AutoMapper;
using CarRental.BLL.Infrastructure;
using CarRental.WEB.App_Start;
using CarRental.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.IoC.Ninject;

namespace CarRental.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfileBll>();
                cfg.AddProfile<MappingProfileWeb>();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule serviceModule = new ServiceModule("RentalContext");
            NinjectModule moduleRegistrations = new NinjectRegistrations();

            var kernel = new StandardKernel(serviceModule, moduleRegistrations);
                kernel.Unbind<ModelValidatorProvider>();

            // use this line without webApi
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            // use this line to work with webApi
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}
