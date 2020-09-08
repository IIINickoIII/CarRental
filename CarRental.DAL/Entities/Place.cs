using System.ComponentModel.DataAnnotations;

namespace CarRental.DAL.Entities
{
    public class Place
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsDelete { get; set; }

        public string Description { get; set; }
    }
}
