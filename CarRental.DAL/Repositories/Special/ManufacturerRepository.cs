using CarRental.DAL.Contexts;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces.Special;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.DAL.Repositories.Special
{
    public class ManufacturerRepository : SpecialRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public Manufacturer Get(int id)
        {
            return RentalContext.Manufacturers.Find(id);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return RentalContext.Manufacturers;
        }

        public IEnumerable<Manufacturer> Find(Expression<Func<Manufacturer, bool>> predicate)
        {
            return RentalContext.Manufacturers.Where(predicate);
        }
        
        public Manufacturer SingleOrDefault(Expression<Func<Manufacturer, bool>> predicate)
        {
            return RentalContext.Manufacturers.SingleOrDefault(predicate);
        }

        public async Task<Manufacturer> FindByNameAsync(string manufacturerName)
        {
            var manufacturer = await RentalContext.Manufacturers.SingleOrDefaultAsync(m => m.Name == manufacturerName);
            return manufacturer;
        }

        public async Task<Manufacturer> UpdateAsync(Manufacturer manufacturer)
        {
            using (var context = new ApplicationContext())
            {
                context.Entry(manufacturer).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            return manufacturer;
        }
    }
}
