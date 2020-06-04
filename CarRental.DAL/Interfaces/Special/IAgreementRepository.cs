using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.DAL.Interfaces.Special
{
    public interface IAgreementRepository : IRepository<Agreement>, ISpecialRepository<Agreement>
    {
        IEnumerable<Agreement> Find(Expression<Func<Agreement, bool>> predicate);
        Agreement SingleOrDefault(Expression<Func<Agreement, bool>> predicate);
    }
}
