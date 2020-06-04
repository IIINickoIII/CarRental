namespace CarRental.BLL.Dto
{
    public class ManufacturerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PictureLink { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public bool IsDeleted { get; set; }
    }
}
