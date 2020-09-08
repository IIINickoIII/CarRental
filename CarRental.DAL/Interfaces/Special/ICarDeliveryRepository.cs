using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.DAL.Interfaces.Special
{
    public interface ICarDeliveryRepository : IRepository<CarDelivery>, ISpecialRepository<CarDelivery>
    {
        IEnumerable<CarDelivery> Find(Expression<Func<CarDelivery, bool>> predicate);
        CarDelivery SingleOrDefault(Expression<Func<CarDelivery, bool>> predicate);
    }
}
