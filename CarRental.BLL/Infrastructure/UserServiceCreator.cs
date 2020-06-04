using CarRental.BLL.Interfaces;
using CarRental.BLL.Services;
using CarRental.DAL.Repositories;

namespace CarRental.BLL.Infrastructure
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new EFUnitOfWork(connection));
        }
    }
}
