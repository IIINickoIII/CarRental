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
    public class CarFeedbackRepository : SpecialRepository<CarFeedback>, ICarFeedbackRepository
    {
        public CarFeedbackRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public IEnumerable<CarFeedback> Find(Expression<Func<CarFeedback, bool>> predicate)
        {
            return RentalContext.CarFeedbacks
                    .Where(predicate)
                    .Include(f => f.Car)
                    .Include(f => f.ClientProfile);
        }

        public CarFeedback Get(int id)
        {
            return RentalContext.CarFeedbacks
                    .Include(f => f.Car)
                    .Include(f => f.ClientProfile)
                    .SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<CarFeedback> GetAll()
        {
            return RentalContext.CarFeedbacks
                    .Include(f => f.Car)
                    .Include(f => f.ClientProfile);
        }

        public CarFeedback SingleOrDefault(Expression<Func<CarFeedback, bool>> predicate)
        {
            return RentalContext.CarFeedbacks
                    .Include(f => f.Car)
                    .Include(f => f.ClientProfile)
                    .SingleOrDefault(predicate);
        }
    }
}
