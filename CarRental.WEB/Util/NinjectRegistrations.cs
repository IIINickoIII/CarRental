using CarRental.BLL.Interfaces;
using CarRental.BLL.Services;
using Ninject.Modules;

namespace CarRental.WEB.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarService>();
            Bind<IManufacturerService>().To<ManufacturerService>();
            Bind<IPlaceService>().To<PlaceService>();
            Bind<IRentService>().To<RentService>();
        }
    }
}