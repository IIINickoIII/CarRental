using CarRental.DAL.Contexts;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces.Special;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CarRental.DAL.Repositories.Special
{
    public class CarRepository : SpecialRepository<Car>, ICarRepository
    {
        public CarRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate)
        {
            return RentalContext.Cars
                        .Where(predicate)
                        .Include(c => c.BodyType)
                        .Include(c => c.CarClass)
                        .Include(c => c.FuelType)
                        .Include(c => c.GearBoxType)
                        .Include(c => c.Manufacturer)
                        .Include(c => c.TransmissionType);
        }

        public Car Get(int id)
        {
            return RentalContext.Cars
                        .Include(c => c.BodyType)
                        .Include(c => c.CarClass)
                        .Include(c => c.FuelType)
                        .Include(c => c.GearBoxType)
                        .Include(c => c.Manufacturer)
                        .Include(c => c.TransmissionType)
                        .SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return RentalContext.Cars
                        .Include(c => c.BodyType)
                        .Include(c => c.CarClass)
                        .Include(c => c.FuelType)
                        .Include(c => c.GearBoxType)
                        .Include(c => c.Manufacturer)
                        .Include(c => c.TransmissionType);
        }

        public Car SingleOrDefault(Expression<Func<Car, bool>> predicate)
        {
            return RentalContext.Cars
                        .Include(c => c.BodyType)
                        .Include(c => c.CarClass)
                        .Include(c => c.FuelType)
                        .Include(c => c.GearBoxType)
                        .Include(c => c.Manufacturer)
                        .Include(c => c.TransmissionType)
                        .SingleOrDefault(predicate);
        }
    }
}
