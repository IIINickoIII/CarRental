using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRental.DAL.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
