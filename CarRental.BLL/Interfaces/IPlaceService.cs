using CarRental.BLL.Dto;
using System.Collections.Generic;

namespace CarRental.BLL.Interfaces
{
    public interface IPlaceService
    {
        PlaceDto Get(int id);

        IEnumerable<PlaceDto> GetAll();

        void Edit(PlaceDto placeDto);

        void Delete(int id);

        void Dispose();
    }
}
