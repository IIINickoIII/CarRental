using CarRental.BLL.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.ViewModels
{
    public class AgreementViewModel
    {
        public int Id { get; set; }

        public RentViewModel rentViewModel { get; set; }

        [Display(Name = "Insurance Type")]
        [Required(ErrorMessage = "Please, select insurance type")]
        public InsuranceType InsuranceType { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please, enter your surname")]
        public string Surname { get; set; }

        [Display(Name = "Personal Id")]
        [Required(ErrorMessage = "Please, enter your personal Id")]
        public string Personald { get; set; }

        public CarDto CarDto { get; set; }

        public int CarId { get; set; }

        public DateTime DateOfAgreement { get; set; }

        [Display(Name = "Do you need a childseat?")]
        public bool WithChildSeat { get; set; }

        [Display(Name = "Do you need a GPS?")]
        public bool WithGPS { get; set; }

        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }

        [Display(Name = "Confirmed")]
        public bool IsConfirmd { get; set; }

        [Display(Name = "Payed")]
        public bool IsPayed { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Personal driver 50$/day")]
        public bool WithDriver { get; set; }

        [Display(Name = "Manager's coment")]
        public string ManagerComment { get; set; }

        [Display(Name = "Pick-up is confirmed")]
        public bool IsPickUped { get; set; }

        [Display(Name = "Return is confirmed")]
        public bool IsReturned { get; set; }
    }
}