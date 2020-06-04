using CarRental.WEB.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CarRental.WEB.Models.CustomValidation
{
    public class NumberOfSeatsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = (CarViewModel)validationContext.ObjectInstance;

            if (car.NumberOfSeats == 0)
                return new ValidationResult("Please enter the number of seats");

            if (car.NumberOfSeats % 1 != 0)
                return new ValidationResult("Number of seats is an integer number");

            if (car.NumberOfSeats > 20)
                return new ValidationResult("Number of seats should be between 1 - 20");

            return ValidationResult.Success;
        }
    }
}