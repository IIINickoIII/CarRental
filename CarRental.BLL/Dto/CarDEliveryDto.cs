using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.BLL.Dto
{
    public class CarDeliveryDto
    {
        public int Id { get; set; }

        public AgreementDto Agreement { get; set; }

        [Required]
        public int AgreementId { get; set; }

        public PlaceDto PlaceDto { get; set; }

        [Required]
        public int PlaceId { get; set; }

        public CarDto CarDto { get; set; }

        public int CarId { get; set; }

        [Required]
        public DateTime DateOfDelivery { get; set; }

        public bool IsDeliveryToUser { get; set; }

        public bool IsCompleted { get; set; }

        public bool NoDamage { get; set; }

        public bool IsDeleted { get; set; }
    }
}
