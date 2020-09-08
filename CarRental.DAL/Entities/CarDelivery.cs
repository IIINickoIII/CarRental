using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class CarDelivery
    {
        public int Id { get; set; }

        public Agreement Agreement { get; set; }

        [Required]
        public int AgreementId { get; set; }

        public Place Place { get; set; }

        [Required]
        public int PlaceId { get; set; }

        public Car Car { get; set; }

        public int? CarId { get; set; }

        [Required]
        public DateTime DateOfDelivery { get; set; }

        public bool IsDeliveryToUser { get; set; }

        public bool IsCompleted { get; set; }

        public bool NoDamage { get; set; }

        public bool IsDeleted { get; set; }
    }
}
