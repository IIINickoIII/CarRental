using CarRental.DAL.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public enum InsuranceType
    {
        None = 0,
        Standard = 1,
        Lux = 2
    }

    public class Agreement
    {
        public int Id { get; set; }

        public InsuranceType InsuranceType { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Personald { get; set; }

        public Car Car { get; set; }

        public int? CarId { get; set; }

        [Required]
        public DateTime DateOfAgreement { get; set; }

        public bool WithChildSeat { get; set; }

        public bool WithGPS { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public bool IsConfirmd { get; set; }

        public bool IsPayed { get; set; }

        public bool IsDeleted { get; set; }

        public bool WithDriver { get; set; }

        public string ManagerComment { get; set; }
    }
}
