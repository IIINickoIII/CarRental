using CarRental.DAL.Entities.Identity;
using System;

namespace CarRental.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
