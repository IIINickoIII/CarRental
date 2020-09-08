using CarRental.BLL.Dto;
using CarRental.BLL.Models;
using System;
using System.Collections.Generic;

namespace CarRental.BLL.Interfaces
{
    public interface ICarService
    {
        CarDto Get(int id);
        IEnumerable<CarDto> GetAllCars();
        IEnumerable<CarDto> GetCarsByOptions(CarSearchModel carSearchModel, DateTime fistDayRent, DateTime lastDayRent);
        IEnumerable<CarDto> GetAvailableCarsForDates(DateTime firstDayRent, DateTime lastDateRent);
        IEnumerable<BodyTypeDto> GetAllBodyTypeDtos();
        IEnumerable<CarClassDto> GetAllCarClassDtos();
        IEnumerable<FuelTypeDto> GetAllFuelTypeDtos();
        IEnumerable<GearboxTypeDto> GetAllGearboxTypeDtos();
        IEnumerable<ManufacturerDto> GetAllManufacturerDtos();
        IEnumerable<TransmissionTypeDto> GetAllTransmissionTypeDtos();
        void Add(CarDto carDto);
        void Edit(CarDto carDto);
        void MarkAsDeleted(int id);
        void MarkAsNotDeleted(int id);
        void Delete(int id);
        void MarkAsAvailable(int id);
        void MarkAsNotAvailable(int id);
        int GetId(CarDto carDto);
        void Dispose();
    }
}
