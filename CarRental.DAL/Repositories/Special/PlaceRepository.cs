using CarRental.DAL.Contexts;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces.Special;
using System.Collections.Generic;
using System.Data.Entity;

namespace CarRental.DAL.Repositories.Special
{
    public class PlaceRepository : SpecialRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public Place Get(int id)
        {
            return RentalContext.Places.Find(id);
        }

        public IEnumerable<Place> GetAll()
        {
            return RentalContext.Places;
        }
    }
}
