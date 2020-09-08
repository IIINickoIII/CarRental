namespace CarRental.BLL.Models
{
    public class CarSearchModel
    {
        public bool? NameAsc { get; set; }

        public bool? ProductionYearAsc { get; set; }

        public bool? WithAirConditioning { get; set; }

        public bool? PriceAsc { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public int? BodyTypeDtoId { get; set; }

        public int? CarClassDtoId { get; set; }

        public int? FuelTypeDtoId { get; set; }

        public int? GearboxTypeDtoId { get; set; }

        public int? ManufacturerDtoId { get; set; }

        public int? TransmissionTypeDtoId { get; set; }
    }
}
