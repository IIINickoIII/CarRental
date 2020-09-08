using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string PictureLink { get; set; }

        public string Description { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string ProductionYear { get; set; }

        [Required]
        public int PricePerDay { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public bool WithAirConditioning { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Required]
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }

        [Required]
        public int GearboxTypeId { get; set; }
        public GearboxType GearBoxType { get; set; }

        [Required]
        public int TransmissionTypeId { get; set; }
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; }

        [Required]
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }

    }
}
