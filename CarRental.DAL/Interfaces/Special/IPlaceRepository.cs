using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Interfaces.Special
{
    public interface IPlaceRepository : IRepository<Place>, ISpecialRepository<Place>
    {
    }
}
