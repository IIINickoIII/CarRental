using CarRental.DAL.Contexts;
using CarRental.DAL.Entities;
using CarRental.DAL.Entities.Identity;
using CarRental.DAL.Identity;
using CarRental.DAL.Interfaces;
using CarRental.DAL.Interfaces.Special;
using CarRental.DAL.Repositories.Special;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace CarRental.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private readonly ApplicationContext _context;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        private CarRepository carRepository;
        private ManufacturerRepository manufacturerRepository;
        private AgreementRepository agreementRepository;
        private CarDeliveryRepository carDeliveryRepository;
        private CarFeedbackRepository carFeedbackRepository;
        private Repository<BodyType> bodyTypeRepository;
        private Repository<CarClass> carClassRepository;
        private Repository<FuelType> fuelTypeRepository;
        private Repository<GearboxType> gearboxTypeRepository;
        private Repository<TransmissionType> transmissionTypeRepository;
        private PlaceRepository placesRepository;

        public EFUnitOfWork(string connectionString)
        {
            _context = new ApplicationContext(connectionString);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if (userManager == null)
                    userManager = new ApplicationUserManager(
                        new UserStore<ApplicationUser>(_context));
                return userManager;
            }
        }

        public IClientManager ClientManager
        {
            get
            {
                if (clientManager == null)
                    clientManager = new ClientManager(_context);
                return clientManager;
            }

        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (roleManager == null)
                    roleManager = new ApplicationRoleManager(
                        new RoleStore<ApplicationRole>(_context));
                return roleManager;
            }
        }

        public ICarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(_context);
                return carRepository;
            }
        }

        public IManufacturerRepository Manufacturers
        {
            get
            {
                if (manufacturerRepository == null)
                    manufacturerRepository =
                        new ManufacturerRepository(_context);
                return manufacturerRepository;
            }
        }

        public IAgreementRepository Agreements
        {
            get
            {
                if (agreementRepository == null)
                    agreementRepository =
                        new AgreementRepository(_context);
                return agreementRepository;
            }
        }

        public ICarDeliveryRepository CarDeliveries
        {
            get
            {
                if (carDeliveryRepository == null)
                    carDeliveryRepository =
                        new CarDeliveryRepository(_context);
                return carDeliveryRepository;
            }
        }

        public ICarFeedbackRepository CarFeedbacks
        {
            get
            {
                if (carFeedbackRepository == null)
                    carFeedbackRepository =
                        new CarFeedbackRepository(_context);
                return carFeedbackRepository;
            }
        }

        public IRepository<BodyType> BodyTypes
        {
            get
            {
                if (bodyTypeRepository == null)
                    bodyTypeRepository =
                        new Repository<BodyType>(_context);
                return bodyTypeRepository;
            }
        }

        public IRepository<CarClass> CarClasses
        {
            get
            {
                if (carClassRepository == null)
                    carClassRepository =
                        new Repository<CarClass>(_context);
                return carClassRepository;
            }
        }

        public IRepository<FuelType> FuelTypes
        {
            get
            {
                if (fuelTypeRepository == null)
                    fuelTypeRepository =
                        new Repository<FuelType>(_context);
                return fuelTypeRepository;
            }
        }

        public IRepository<GearboxType> GearboxTypes
        {
            get
            {
                if (gearboxTypeRepository == null)
                    gearboxTypeRepository =
                        new Repository<GearboxType>(_context);
                return gearboxTypeRepository;
            }
        }

        public IRepository<TransmissionType> TransmissionTypes
        {
            get
            {
                if (transmissionTypeRepository == null)
                    transmissionTypeRepository =
                        new Repository<TransmissionType>(_context);
                return transmissionTypeRepository;
            }
        }

        public IPlaceRepository Places
        {
            get
            {
                if (placesRepository == null)
                    placesRepository =
                        new PlaceRepository(_context);
                return placesRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~EFUnitOfWork()
        {
            Dispose(false);
        }
    }
}
