using CarRental.BLL.Dto;
using System.Collections.Generic;

namespace CarRental.WEB.ViewModels
{
    public class CarFormViewModel
    {
        public CarViewModel CarViewModel { get; set; }

        public IEnumerable<BodyTypeDto> BodyTypeDtos { get; set; }

        public IEnumerable<CarClassDto> CarClassDtos { get; set; }

        public IEnumerable<FuelTypeDto> FuelTypeDtos { get; set; }

        public IEnumerable<GearboxTypeDto> GearboxTypeDtos { get; set; }

        public IEnumerable<ManufacturerDto> ManufacturerDtos { get; set; }

        public IEnumerable<TransmissionTypeDto> TransmissionTypeDtos { get; set; }

        public CarFormViewModel() { }

        public CarFormViewModel(
            CarViewModel carViewModel,
            IEnumerable<BodyTypeDto> bodyTypeDtos,
            IEnumerable<CarClassDto> carClassDtos,
            IEnumerable<FuelTypeDto> fuelTypeDtos,
            IEnumerable<GearboxTypeDto> gearboxTypeDtos,
            IEnumerable<ManufacturerDto> manufacturerDtos,
            IEnumerable<TransmissionTypeDto> transmissionTypeDtos)
        {
            CarViewModel = carViewModel;
            BodyTypeDtos = bodyTypeDtos;
            CarClassDtos = carClassDtos;
            FuelTypeDtos = fuelTypeDtos;
            GearboxTypeDtos = gearboxTypeDtos;
            ManufacturerDtos = manufacturerDtos;
            TransmissionTypeDtos = transmissionTypeDtos;
        }
    }
}