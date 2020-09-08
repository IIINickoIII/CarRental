using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CarRental.BLL.Services
{
    public class PlaceService : IPlaceService
    {
        IUnitOfWork Database { get; set; }

        public PlaceService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public PlaceDto Get(int id)
        {
            var place = Database.Places.Get(id);
            var placeDto = Mapper.Map<PlaceDto>(place);
            return placeDto;
        }

        public IEnumerable<PlaceDto> GetAll()
        {
            var places = Database.Places.GetAll();
            var placeDtos = Mapper.Map<IEnumerable<PlaceDto>>(places);
            return placeDtos;
        }

        public void Edit(PlaceDto placeDto)
        {
            var place = Mapper.Map<Place>(placeDto);
            Database.Places.Update(place);
            Database.Save();
        }

        public void Delete(int id)
        {
            var placeInDb = Database.Places.Get(id);

            if(placeInDb == null)
                throw new Exception("Not found");

            Database.Places.Remove(placeInDb);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
