using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.DAL.Interfaces.Special
{
    public interface ICarFeedbackRepository : IRepository<CarFeedback>, ISpecialRepository<CarFeedback>
    {
        IEnumerable<CarFeedback> Find(Expression<Func<CarFeedback, bool>> predicate);
        CarFeedback SingleOrDefault(Expression<Func<CarFeedback, bool>> predicate);
    }
}
