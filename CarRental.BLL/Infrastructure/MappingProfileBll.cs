using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.DAL.Entities;
using CarRental.DAL.Entities.Identity;
using System;
using System.Linq;

namespace CarRental.BLL.Infrastructure
{
    public class MappingProfileBll : Profile
    {
        public MappingProfileBll()
        {
            Mapper.CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();

            Mapper.CreateMap<BodyType, BodyTypeDto>().ReverseMap();

            Mapper.CreateMap<CarClass, CarClassDto>().ReverseMap();

            Mapper.CreateMap<FuelType, FuelTypeDto>().ReverseMap();

            Mapper.CreateMap<GearboxType, GearboxTypeDto>().ReverseMap();

            Mapper.CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();

            Mapper.CreateMap<TransmissionType, TransmissionTypeDto>().ReverseMap();

            Mapper.CreateMap<Car, CarDto>()
                .ForMember(c => c.BodyTypeDto, opt => opt.MapFrom(src => src.BodyType))
                .ForMember(c => c.CarClassDto, opt => opt.MapFrom(src => src.CarClass))
                .ForMember(c => c.FuelTypeDto, opt => opt.MapFrom(src => src.FuelType))
                .ForMember(c => c.GearBoxTypeDto, opt => opt.MapFrom(src => src.GearBoxType))
                .ForMember(c => c.ManufacturerDto, opt => opt.MapFrom(src => src.Manufacturer))
                .ForMember(c => c.TransmissionTypeDto, opt => opt.MapFrom(src => src.TransmissionType))
                .ReverseMap();

            Mapper.CreateMap<Place, PlaceDto>().ReverseMap();

            Mapper.CreateMap<Agreement, AgreementDto>()
                .ForMember(a => a.CarDto, opt => opt.MapFrom(src => src.Car))
                .ReverseMap();

            Mapper.CreateMap<CarDelivery, CarDeliveryDto>()
                .ForMember(cd => cd.Agreement, opt => opt.MapFrom(src => src.Agreement))
                .ForMember(cd => cd.PlaceDto, opt => opt.MapFrom(src => src.Place))
                .ReverseMap();

            Mapper.CreateMap<ClientProfile, ClientProfileDto>().ReverseMap();

            Mapper.CreateMap<ApplicationUser, UserDto>()
                .ForMember(m => m.RoleId, opt => opt.MapFrom(src => src.Roles.First().RoleId))
                .ForMember(m => m.Name, opt => opt.MapFrom(src => src.ClientProfile.Name))
                .ForMember(m => m.Address, opt => opt.MapFrom(src => src.ClientProfile.Address))
                .ForMember(m => m.Password, opt => opt.MapFrom(src => src.PasswordHash))
                .ReverseMap();

            Mapper.CreateMap<ApplicationUser, String>()
                .ConvertUsing(u => u.UserName);

            Mapper.CreateMap<ApplicationRole, RoleDto>().ReverseMap();
        }
    }
}
