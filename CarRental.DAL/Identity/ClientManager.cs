using CarRental.DAL.Contexts;
using CarRental.DAL.Entities.Identity;
using CarRental.DAL.Interfaces;

namespace CarRental.DAL.Identity
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
