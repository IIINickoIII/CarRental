using CarRental.BLL.Dto;
using CarRental.WEB.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.ViewModels
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }

        public Picture Picture { get; set; }

        [Required(ErrorMessage = "Please, enter the name")]
        [StringLength(255)]
        public string Name { get; set; }

        public string PictureLink { get; set; }

        [Display(Name = "About manufacturer")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please, enter the country")]
        [StringLength(255)]
        public string Country { get; set; }


        public bool IsDeleted { get; set; }


        public string Title
        {
            get
            {
                return (Id == 0) ? "New manufacturer" : "Editing manufacturer";
            }
        }

        public bool IsNewCreated
        {
            get
            {
                return (Id == 0);
            }
        }

        public ManufacturerViewModel()
        {
            Id = 0;
        }

        public ManufacturerViewModel(ManufacturerDto manufacturerDto)
        {
            Id = manufacturerDto.Id;
            Name = manufacturerDto.Name;
            Description = manufacturerDto.Description;
            Country = manufacturerDto.Country;
        }
    }
}