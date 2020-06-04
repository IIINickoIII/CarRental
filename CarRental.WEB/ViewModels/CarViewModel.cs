using CarRental.BLL.Dto;
using CarRental.WEB.Models.CustomValidation;
using System;
using CarRental.WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Car model")]
        [Required(ErrorMessage = "Please enter car model")]
        public string Name { get; set; }

        public Picture Picture { get; set; }

        public string PictureLink { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                if (Description != null)
                {
                    return $"{Description.Substring(0, Math.Min(Description.Length, 100))}...";
                }
                else
                {
                    return "";
                }
            }
        }

        [Display(Name = "License plate")]
        [Required(ErrorMessage = "Plese enter the license plate")]
        public string LicensePlate { get; set; }

        [Display(Name = "Production year")]
        [Required(ErrorMessage = "Please enter production year")]
        public string ProductionYear { get; set; }

        [Display(Name = "Price per day")]
        [Required(ErrorMessage = "Please enter price per day")]
        public int PricePerDay { get; set; }

        [Display(Name = "Number of seats")]
        [Required(ErrorMessage = "Please enter the number of seats")]
        [Range(1, 20)]
        public int NumberOfSeats { get; set; }

        [Display(Name = "With air conditioner")]
        public bool WithAirConditioning { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }


        public ManufacturerDto ManufacturerDto { get; set; }
        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Please choose manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Fuel")]
        [Required(ErrorMessage = "Please choose fuel type")]
        public int FuelTypeId { get; set; }

        [Display(Name = "Gearbox")]
        [Required(ErrorMessage = "Please choose gearbox type")]
        public int GearboxTypeId { get; set; }

        [Display(Name = "Transmission")]
        [Required(ErrorMessage = "Please choose transmission type")]
        public int TransmissionTypeId { get; set; }

        [Display(Name = "Class")]
        [Required(ErrorMessage = "Please choose body type")]
        public int CarClassId { get; set; }

        [Display(Name = "Body")]
        [Required(ErrorMessage = "Please choose body type")]
        public int BodyTypeId { get; set; }

        public string Title
        {
            get
            {
                return (Id == 0) ? "New car" : "Editing car";
            }
        }

        public bool IsNewCreated
        {
            get
            {
                return (Id == 0);
            }
        }

        public CarViewModel()
        {
            Id = 0;
        }

        public CarViewModel(CarDto carDto)
        {
            Id = carDto.Id;
            Name = carDto.Name;
            Description = carDto.Description;
            LicensePlate = carDto.LicensePlate;
            ProductionYear = carDto.ProductionYear;
            PricePerDay = carDto.PricePerDay;
            NumberOfSeats = carDto.NumberOfSeats;
            WithAirConditioning = carDto.WithAirConditioning;
            IsAvailable = carDto.IsAvailable;
            IsDeleted = carDto.IsDeleted;
            ManufacturerId = carDto.ManufacturerId;
            FuelTypeId = carDto.FuelTypeId;
            GearboxTypeId = carDto.GearboxTypeId;
            TransmissionTypeId = carDto.TransmissionTypeId;
            CarClassId = carDto.CarClassId;
            BodyTypeId = carDto.BodyTypeId;
        }
    }
}