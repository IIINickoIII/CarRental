using CarRental.DAL.Interfaces;
using System.Data.Entity;

namespace CarRental.DAL.Repositories
{
    public class SpecialRepository<TEntity> : ISpecialRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public SpecialRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
