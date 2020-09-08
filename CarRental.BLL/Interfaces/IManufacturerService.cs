using CarRental.BLL.Dto;
using CarRental.BLL.Infrastructure;
using CarRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.BLL.Interfaces
{
    public interface IManufacturerService
    {
        ManufacturerDto Get(int id);
        int GetId(ManufacturerDto manufacturerDto);
        IEnumerable<ManufacturerDto> GetAll();
        Task<OperationDetails> AddAsync(ManufacturerDto manufacturerDto);
        Task<OperationDetails> EditAcync(ManufacturerDto manufacturerDto);
        void Add(ManufacturerDto manufacturerDto);
        void Edit(ManufacturerDto manufacturerDto);
        void MarkAsDeleted(int id);
        void MarkAsNotDeleted(int id);
        void Delete(int id);
        void Dispose();
    }
}
