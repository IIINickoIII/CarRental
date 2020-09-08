using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.DAL.Interfaces.Special
{
    public interface IManufacturerRepository : IRepository<Manufacturer>, ISpecialRepository<Manufacturer>
    {
        IEnumerable<Manufacturer> Find(Expression<Func<Manufacturer, bool>> predicate);
        Manufacturer SingleOrDefault(Expression<Func<Manufacturer, bool>> predicate);
        Task<Manufacturer> FindByNameAsync(string manufacturerName);
        Task<Manufacturer> UpdateAsync(Manufacturer manufacturer);
    }
}
