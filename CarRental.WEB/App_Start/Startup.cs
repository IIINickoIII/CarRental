using CarRental.BLL.Infrastructure;
using CarRental.BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(CarRental.WEB.App_Start.Startup))]

namespace CarRental.WEB.App_Start
{
    public class Startup
    {
        // С помощью фабрики сервисов здесь создается сервис для работы с сервисами
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            // сервис региструется контекстом OWIN
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("RentalContext");
        }
    }
}