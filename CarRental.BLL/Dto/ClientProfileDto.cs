using CarRental.DAL.Entities.Identity;

namespace CarRental.BLL.Dto
{
    public class ClientProfileDto
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
