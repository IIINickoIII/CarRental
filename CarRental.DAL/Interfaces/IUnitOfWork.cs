using CarRental.DAL.Entities;
using CarRental.DAL.Identity;
using CarRental.DAL.Interfaces.Special;
using System;
using System.Threading.Tasks;

namespace CarRental.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        ICarRepository Cars { get; }
        IManufacturerRepository Manufacturers { get; }
        IRepository<BodyType> BodyTypes { get; }
        IRepository<CarClass> CarClasses { get; }
        IRepository<FuelType> FuelTypes { get; }
        IRepository<GearboxType> GearboxTypes { get; }
        IRepository<TransmissionType> TransmissionTypes { get; }
        IPlaceRepository Places { get; }
        IAgreementRepository Agreements { get; }
        ICarDeliveryRepository CarDeliveries { get; }
        ICarFeedbackRepository CarFeedbacks { get; }
        Task SaveAsync();
        void Save();
    }
}
