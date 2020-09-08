using CarRental.BLL.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.ViewModels
{
    public class CarSearchViewModel
    {
        public IEnumerable<CarViewModel> CarViewModels { get; set; }

        public RentViewModel rentViewModel { get; set; }

        [Display(Name = "Sort by name")]
        public bool? NameAsc { get; set; }


        [Display(Name = "Sort by production year")]
        public bool? ProductionYearAsc { get; set; }


        [Display(Name = "With air conditioning")]
        public bool? WithAirConditioning { get; set; }


        [Display(Name = "Sort by price")]
        public bool? PriceAsc { get; set; }


        [Display(Name = "Minimal price")]
        public int? MinPrice { get; set; }


        [Display(Name = "Maximum price")]
        public int? MaxPrice { get; set; }

        public IEnumerable<BodyTypeDto> BodyTypeDtos { get; set; }

        [Display(Name = "Select body type")]
        public int? BodyTypeDtoId { get; set; }

        public IEnumerable<CarClassDto> CarClassDtos { get; set; }

        [Display(Name = "Select car class")]
        public int? CarClassDtoId { get; set; }

        public IEnumerable<FuelTypeDto> FuelTypeDtos { get; set; }


        [Display(Name = "Select fuel type")]
        public int? FuelTypeDtoId { get; set; }

        public IEnumerable<GearboxTypeDto> GearboxTypeDtos { get; set; }

        [Display(Name = "Select gearbox type")]
        public int? GearboxTypeDtoId { get; set; }

        public IEnumerable<ManufacturerDto> ManufacturerDtos { get; set; }

        [Display(Name = "Select manufacturer")]
        public int? ManufacturerDtoId { get; set; }

        public IEnumerable<TransmissionTypeDto> TransmissionTypeDtos { get; set; }

        [Display(Name = "Select transmission type")]
        public int? TransmissionTypeDtoId { get; set; }

        public CarSearchViewModel() { }

        public CarSearchViewModel(
            IEnumerable<CarViewModel> carViewModel,
            IEnumerable<BodyTypeDto> bodyTypeDtos,
            IEnumerable<CarClassDto> carClassDtos,
            IEnumerable<FuelTypeDto> fuelTypeDtos,
            IEnumerable<GearboxTypeDto> gearboxTypeDtos,
            IEnumerable<ManufacturerDto> manufacturerDtos,
            IEnumerable<TransmissionTypeDto> transmissionTypeDtos)
        {
            CarViewModels = carViewModel;
            BodyTypeDtos = bodyTypeDtos;
            CarClassDtos = carClassDtos;
            FuelTypeDtos = fuelTypeDtos;
            GearboxTypeDtos = gearboxTypeDtos;
            ManufacturerDtos = manufacturerDtos;
            TransmissionTypeDtos = transmissionTypeDtos;
        }
    }
}