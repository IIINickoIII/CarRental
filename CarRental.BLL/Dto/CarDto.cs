namespace CarRental.BLL.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PictureLink { get; set; }

        public string Description { get; set; }

        public string LicensePlate { get; set; }

        public string ProductionYear { get; set; }

        public int PricePerDay { get; set; }

        public int NumberOfSeats { get; set; }

        public bool WithAirConditioning { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerDto ManufacturerDto { get; set; }

        public int FuelTypeId { get; set; }
        public FuelTypeDto FuelTypeDto { get; set; }

        public int GearboxTypeId { get; set; }
        public GearboxTypeDto GearBoxTypeDto { get; set; }

        public int TransmissionTypeId { get; set; }
        public TransmissionTypeDto TransmissionTypeDto { get; set; }

        public int CarClassId { get; set; }
        public CarClassDto CarClassDto { get; set; }

        public int BodyTypeId { get; set; }
        public BodyTypeDto BodyTypeDto { get; set; }
    }
}
