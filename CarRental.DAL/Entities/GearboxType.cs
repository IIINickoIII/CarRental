using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class GearboxType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
