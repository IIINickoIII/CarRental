using System;

namespace CarRental.BLL.Dto
{
    public enum InsuranceType
    {
        None = 0,
        Standard = 1,
        Lux = 2
    }

    public class AgreementDto
    {
        public int Id { get; set; }

        public InsuranceType InsuranceType { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Personald { get; set; }

        public CarDto CarDto { get; set; }

        public int CarId { get; set; }

        public DateTime DateOfAgreement { get; set; }

        public bool WithChildSeat { get; set; }

        public bool WithGPS { get; set; }

        public int NumberOfDays { get; set; }

        public int TotalPrice { get; set; }

        public bool IsConfirmd { get; set; }

        public bool IsPayed { get; set; }

        public bool IsDeleted { get; set; }

        public bool WithDriver { get; set; }

        public string ManagerComment { get; set; }
    }
}
