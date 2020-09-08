using CarRental.DAL.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class CarFeedback
    {
        public int Id { get; set; }

        public Car Car { get; set; }

        [Required]
        public int CarId { get; set; }

        public ClientProfile ClientProfile { get; set; }

        [Required]
        [StringLength(128)]
        public string ClientProfileId { get; set; }

        [Required]
        public DateTime DateOfFeedback { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsDeleted { get; set; }
    }
}
