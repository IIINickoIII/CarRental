using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.BLL.Models;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.BLL.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork Database { get; set; }

        public CarService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(CarDto carDto)
        {
            var car = Mapper.Map<Car>(carDto);

            Database.Cars.Add(car);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(CarDto carDto)
        {
            var car = Mapper.Map<Car>(carDto);

            Database.Cars.Update(car);
            Database.Save();
        }

        public CarDto Get(int id)
        {
            Car car = Database.Cars.Get(id);

            if (car == null)
                return null;

            return Mapper.Map<CarDto>(car);
        }

        public IEnumerable<CarDto> GetAllCars()
        {
            var cars = Database.Cars.GetAll();
            return Mapper.Map<List<CarDto>>(cars);
        }

        public void MarkAsDeleted(int id)
        {
            var car = Database.Cars.Get(id);

            car.IsDeleted = true;

            Database.Cars.Update(car);
            Database.Save();
        }

        public void MarkAsNotDeleted(int id)
        {
            var car = Database.Cars.Get(id);

            car.IsDeleted = false;

            Database.Cars.Update(car);
            Database.Save();
        }

        public void MarkAsAvailable(int id)
        {
            var car = Database.Cars.Get(id);

            car.IsAvailable = true;

            Database.Cars.Update(car);
            Database.Save();
        }

        public void MarkAsNotAvailable(int id)
        {
            var car = Database.Cars.Get(id);

            car.IsAvailable = false;

            Database.Cars.Update(car);
            Database.Save();
        }

        public IEnumerable<BodyTypeDto> GetAllBodyTypeDtos()
        {
            var bodyTypes = Database.BodyTypes.GetAll();
            return Mapper.Map<List<BodyTypeDto>>(bodyTypes);
        }

        public IEnumerable<CarClassDto> GetAllCarClassDtos()
        {
            var carClasses = Database.CarClasses.GetAll();
            return Mapper.Map<List<CarClassDto>>(carClasses);
        }

        public IEnumerable<FuelTypeDto> GetAllFuelTypeDtos()
        {
            var fuelTypes = Database.FuelTypes.GetAll();
            return Mapper.Map<List<FuelTypeDto>>(fuelTypes);
        }

        public IEnumerable<GearboxTypeDto> GetAllGearboxTypeDtos()
        {
            var gearboxeTypes = Database.GearboxTypes.GetAll();
            return Mapper.Map<List<GearboxTypeDto>>(gearboxeTypes);
        }

        public IEnumerable<ManufacturerDto> GetAllManufacturerDtos()
        {
            var manufacturers = Database.Manufacturers.GetAll();
            return Mapper.Map<List<ManufacturerDto>>(manufacturers);
        }

        public IEnumerable<TransmissionTypeDto> GetAllTransmissionTypeDtos()
        {
            var transmissionTypes = Database.TransmissionTypes.GetAll();
            return Mapper.Map<List<TransmissionTypeDto>>(transmissionTypes);
        }

        public void Delete(int id)
        {
            var carInDb = Database.Cars.Get(id);

            if (carInDb == null)
                throw new System.Exception("Not Found");

            Database.Cars.Remove(carInDb);
            Database.Save();
        }

        public int GetId(CarDto carDto)
        {
            var carInDb = Database.Cars.GetAll().Last();
            if (carInDb.BodyTypeId == carDto.BodyTypeId &
                carInDb.CarClassId == carDto.CarClassId &
                carInDb.Description == carDto.Description &
                carInDb.FuelTypeId == carDto.FuelTypeId &
                carInDb.GearboxTypeId == carDto.GearboxTypeId &
                carInDb.IsAvailable == carDto.IsAvailable &
                carInDb.IsDeleted == carDto.IsDeleted &
                carInDb.LicensePlate == carDto.LicensePlate &
                carInDb.ManufacturerId == carDto.ManufacturerId &
                carInDb.Name == carDto.Name &
                carInDb.NumberOfSeats == carDto.NumberOfSeats &
                carInDb.PricePerDay == carDto.PricePerDay &
                carInDb.ProductionYear == carDto.ProductionYear &
                carInDb.TransmissionTypeId == carDto.TransmissionTypeId &
                carInDb.WithAirConditioning == carDto.WithAirConditioning &
                carInDb.PictureLink == carDto.PictureLink)
            {
                return carInDb.Id;
            }
            else return carDto.Id;
        }

        public IEnumerable<CarDto> GetAvailableCarsForDates(DateTime firstDayRent, DateTime lastDayRent)
        {
            var carDeliveries = Database.CarDeliveries.GetAll().ToList();

            IEnumerable<Car> cars;

            if (carDeliveries.Count() != 0)
            {
                var notAvailableCars = carDeliveries
                    .Where(cd => cd.DateOfDelivery.Date >= firstDayRent.Date &&
                                 cd.DateOfDelivery.Date <= lastDayRent.Date &&
                                 cd.IsDeleted != true)
                    .Select(cd => cd.CarId).ToList();

                var carRentsBeforeOurRent = carDeliveries
                    .Where(cd => cd.IsDeliveryToUser == true &&
                                 cd.DateOfDelivery.Date <= firstDayRent.Date &&
                                 cd.IsDeleted != true);

                if (carRentsBeforeOurRent != null)
                {
                    foreach (var carRentBefore in carRentsBeforeOurRent)
                    {
                        var agreementId = carRentBefore.AgreementId;
                        var returnCar = carDeliveries
                            .SingleOrDefault(cd => cd.AgreementId == agreementId & cd.IsDeliveryToUser == false);

                        if (returnCar.DateOfDelivery.Date >= lastDayRent.Date)
                        {
                            notAvailableCars.Add(returnCar.CarId);
                        }
                    }
                }
                if (notAvailableCars.Count() == 0)
                {
                    cars = Database.Cars.GetAll();

                    return Mapper.Map<IEnumerable<CarDto>>(cars);
                }

                var carsInDb = Database.Cars.GetAll().ToList();

                //cars = carsInDb.Where(car => availableCarsId.Any(id => car.Id == id));
                var carsNotAvailable = carsInDb.Where(car => notAvailableCars.Any(id => car.Id == id)).ToList();
                cars = carsInDb.Except(carsNotAvailable).ToList();

                return Mapper.Map<IEnumerable<CarDto>>(cars);

            }
            cars = Database.Cars.GetAll();

            return Mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public IEnumerable<CarDto> GetCarsByOptions(CarSearchModel carSearchModel, DateTime firstDayRent, DateTime lastDayRent)
        {
            IEnumerable<CarDto> cars = GetAvailableCarsForDates(firstDayRent, lastDayRent);

            if (carSearchModel.ManufacturerDtoId.HasValue)
            {
                cars = cars.Where(c => c.ManufacturerId == carSearchModel.ManufacturerDtoId.Value);
            }
            if (carSearchModel.GearboxTypeDtoId.HasValue)
            {
                cars = cars.Where(c => c.GearboxTypeId == carSearchModel.GearboxTypeDtoId.Value);
            }
            if (carSearchModel.FuelTypeDtoId.HasValue)
            {
                cars = cars.Where(c => c.FuelTypeId == carSearchModel.FuelTypeDtoId.Value);
            }
            if (carSearchModel.CarClassDtoId.HasValue)
            {
                cars = cars.Where(c => c.CarClassId == carSearchModel.CarClassDtoId.Value);
            }
            if (carSearchModel.BodyTypeDtoId.HasValue)
            {
                cars = cars.Where(c => c.BodyTypeId == carSearchModel.BodyTypeDtoId.Value);
            }
            if (carSearchModel.TransmissionTypeDtoId.HasValue)
            {
                cars = cars.Where(c => c.TransmissionTypeId == carSearchModel.TransmissionTypeDtoId.Value);
            }
            if (carSearchModel.MinPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay >= carSearchModel.MinPrice.Value);
            }
            if (carSearchModel.MaxPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay <= carSearchModel.MaxPrice.Value);
            }
            if (carSearchModel.WithAirConditioning.HasValue)
            {
                cars = cars.Where(c => c.WithAirConditioning == carSearchModel.WithAirConditioning.Value);
            }
            if (carSearchModel.NameAsc.HasValue)
            {
                if (carSearchModel.NameAsc.Value)
                    cars = cars.OrderBy(c => c.Name);
                else
                    cars = cars.OrderByDescending(c => c.Name);
            }
            if (carSearchModel.PriceAsc.HasValue)
            {
                if (carSearchModel.PriceAsc.Value)
                    cars = cars.OrderBy(c => c.PricePerDay);
                else
                    cars = cars.OrderByDescending(c => c.PricePerDay);
            }
            if (carSearchModel.ProductionYearAsc.HasValue)
            {
                if (carSearchModel.ProductionYearAsc.Value)
                    cars = cars.OrderBy(c => c.ProductionYear);
                else
                    cars = cars.OrderByDescending(c => c.ProductionYear);
            }

            return cars;
        }
    }
}
