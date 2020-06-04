using CarRental.BLL.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.ViewModels
{
    public class RentViewModel
    {
        [Display(Name = "Pick-up location")]
        public PlaceDto PickUpLocation { get; set; }

        [Required(ErrorMessage = "Please, select pick-up location")]
        public int PickUpLocationId { get; set; }

        [Display(Name = "Return location")]
        public PlaceDto ReturnLocation { get; set; }

        [Required(ErrorMessage = "Please, select return location")]
        public int ReturnLocationId { get; set; }

        public IEnumerable<PlaceDto> Locations { get; set; }

        [Required(ErrorMessage = "Please, select pick-up date")]
        [Display(Name = "Pick-up date")]
        public DateTime firstDayRent { get; set; }

        [Required(ErrorMessage = "Please, select return date")]
        [Display(Name = "Return date")]
        public DateTime lastDayRent { get; set; }

    }
}