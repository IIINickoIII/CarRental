namespace CarRental.DAL.Interfaces
{
    public interface ISpecialRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
