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
    public class AgreementRepository : SpecialRepository<Agreement>, IAgreementRepository
    {
        public AgreementRepository(DbContext context)
            : base(context) { }

        public ApplicationContext RentalContext
        {
            get { return Context as ApplicationContext; }
        }

        public IEnumerable<Agreement> Find(Expression<Func<Agreement, bool>> predicate)
        {
            return RentalContext.Agreements
                    .Where(predicate)
                    .Include(a => a.Car);
        }

        public Agreement Get(int id)
        {
            return RentalContext.Agreements
                    .Include(a => a.Car)
                    .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Agreement> GetAll()
        {
            return RentalContext.Agreements
                    .Include(a => a.Car);
        }

        public Agreement SingleOrDefault(Expression<Func<Agreement, bool>> predicate)
        {
            return RentalContext.Agreements
                    .Include(a => a.Car)
                    .SingleOrDefault(predicate);
        }
    }
}
