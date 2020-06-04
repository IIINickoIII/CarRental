using CarRental.DAL.Entities;
using CarRental.DAL.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarRental.DAL.Contexts
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("RentalContext") { }

        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<BodyType> BodyTypes { get; set; }

        public DbSet<CarClass> CarClasses { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<GearboxType> GearboxTypes { get; set; }

        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        public DbSet<CarFeedback> CarFeedbacks { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Agreement> Agreements { get; set; }

        public DbSet<CarDelivery> CarDeliveries { get; set; }

    }
}
