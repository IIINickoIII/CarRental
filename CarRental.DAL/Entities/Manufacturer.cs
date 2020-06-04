using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string PictureLink { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        public bool IsDeleted { get; set; }
    }
}
