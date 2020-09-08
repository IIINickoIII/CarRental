using CarRental.DAL.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace CarRental.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        { }
    }
}
