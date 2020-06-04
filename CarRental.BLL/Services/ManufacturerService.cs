using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Infrastructure;
using CarRental.BLL.Interfaces;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.BLL.Services
{
    public class ManufacturerService : IManufacturerService
    {
        IUnitOfWork Database { get; set; }

        public ManufacturerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<Manufacturer>(manufacturerDto);

            Database.Manufacturers.Add(manufacturer);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Edit(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<Manufacturer>(manufacturerDto);

            Database.Manufacturers.Update(manufacturer);
            Database.Save();
        }

        public ManufacturerDto Get(int id)
        {
            Manufacturer manufacturer = Database.Manufacturers.Get(id);
            if (manufacturer == null)
                return null;

            return Mapper.Map<ManufacturerDto>(manufacturer);
        }

        public IEnumerable<ManufacturerDto> GetAll()
        {
            var manufacturers = Database.Manufacturers.GetAll();
            return Mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
        }

        public void MarkAsDeleted(int id)
        {
            var manufacturer = Database.Manufacturers.Get(id);
            manufacturer.IsDeleted = true;

            Database.Manufacturers.Update(manufacturer);
            Database.Save();
        }

        public void MarkAsNotDeleted(int id)
        {
            var manufacturer = Database.Manufacturers.Get(id);
            manufacturer.IsDeleted = false;

            Database.Manufacturers.Update(manufacturer);
            Database.Save();
        }

        public async Task<OperationDetails> AddAsync(ManufacturerDto manufacturerDto)
        {
            Manufacturer manufacturerInDb = await Database.Manufacturers.FindByNameAsync(manufacturerDto.Name);
            if (manufacturerInDb == null)
            {
                var manufacturer = Mapper.Map<Manufacturer>(manufacturerDto);

                Database.Manufacturers.Add(manufacturer);
                Database.Save();
                return new OperationDetails(true, "Manufacturer was added.", "");
            }
            else
            {
                return new OperationDetails(false, "This name is already taken.", "Name");
            }
        }

        public async Task<OperationDetails> EditAcync(ManufacturerDto manufacturerDto)
        {
            Manufacturer manufacturerInDb = Database.Manufacturers
                .SingleOrDefault(m => m.Name == manufacturerDto.Name);
            if (manufacturerInDb == null ||
                (manufacturerInDb != null &&
                 manufacturerInDb.Id == manufacturerDto.Id))
            {
                manufacturerInDb = Mapper.Map<Manufacturer>(manufacturerDto);
                await Database.Manufacturers.UpdateAsync(manufacturerInDb);
                Database.Save();
                return new OperationDetails(true, "Manufacturer was updated.", "");
            }
            return new OperationDetails(false, "This name is already taken.", "Name");
        }

        public int GetId(ManufacturerDto manufacturerDto)
        {
            var manufacturerInDb = Database.Manufacturers.GetAll().Last();
            if (manufacturerDto.Name == manufacturerInDb.Name &
                manufacturerDto.IsDeleted == manufacturerInDb.IsDeleted &
                manufacturerDto.Country == manufacturerInDb.Country &
                manufacturerDto.Description == manufacturerInDb.Description &
                manufacturerDto.PictureLink == manufacturerInDb.PictureLink)
            {
                return manufacturerInDb.Id;
            }
            else return manufacturerDto.Id;
        }

        public void Delete(int id)
        {
            var manufacturerInDb = Database.Manufacturers.Get(id);

            if (manufacturerInDb == null)
                throw new System.Exception("Not found");

            Database.Manufacturers.Remove(manufacturerInDb);
            Database.Save();
        }
    }
}
