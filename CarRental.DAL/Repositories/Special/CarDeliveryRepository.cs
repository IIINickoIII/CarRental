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
    public class CarDeliveryRepository : SpecialRepository<CarDelivery>, ICarDeliveryRepository
    {
        public CarDeliveryRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public IEnumerable<CarDelivery> Find(Expression<Func<CarDelivery, bool>> predicate)
        {
            return RentalContext.CarDeliveries
                    .Where(predicate)
                    .Include(d => d.Agreement)
                    .Include(d => d.Place);
        }

        public CarDelivery Get(int id)
        {
            return RentalContext.CarDeliveries
                    .Include(d => d.Agreement)
                    .Include(d => d.Place)
                    .SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<CarDelivery> GetAll()
        {
            return RentalContext.CarDeliveries
                    .Include(d => d.Agreement)
                    .Include(d => d.Place);
        }

        public CarDelivery SingleOrDefault(Expression<Func<CarDelivery, bool>> predicate)
        {
            return RentalContext.CarDeliveries
                    .Include(d => d.Agreement)
                    .Include(d => d.Place)
                    .SingleOrDefault(predicate);
        }
    }
}
