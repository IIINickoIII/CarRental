using CarRental.DAL.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace CarRental.DAL.Interfaces.Special
{
    public interface ICarRepository : IRepository<Car>, ISpecialRepository<Car>
    {
        IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate);
        Car SingleOrDefault(Expression<Func<Car, bool>> predicate);
    }
}
