using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Models;
using CarRental.WEB.ViewModels;

namespace CarRental.WEB.App_Start
{
    public class MappingProfileWeb : Profile
    {
        public MappingProfileWeb()
        {
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>().ReverseMap();

            Mapper.CreateMap<CarDto, CarViewModel>()
                .ForMember(c => c.ManufacturerDto, opt => opt
                .MapFrom(src => src.ManufacturerDto))
                .ReverseMap();

            Mapper.CreateMap<CarSearchModel, CarSearchViewModel>()
                .ReverseMap();

            Mapper.CreateMap<AgreementDto, AgreementViewModel>().ReverseMap();
        }
    }
}