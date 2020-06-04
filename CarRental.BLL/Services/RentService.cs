using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.BLL.Services
{
    public class RentService : IRentService
    {
        IUnitOfWork Database { get; set; }

        public RentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int AddAgreement(AgreementDto agreementDto)
        {
            var agreement = Mapper.Map<Agreement>(agreementDto);

            Database.Agreements.Add(agreement);
            Database.Save();

            var carInDb = Database.Cars.Get(agreement.CarId.Value);
            carInDb.IsAvailable = false;

            Database.Cars.Update(carInDb);
            Database.Save();

            return agreement.Id;
        }

        public void AddCarDelivery(CarDeliveryDto carDeliveryDto)
        {
            var carDelivery = Mapper.Map<CarDelivery>(carDeliveryDto);

            Database.CarDeliveries.Add(carDelivery);
            Database.Save();
        }

        public IEnumerable<AgreementDto> GetAgreementsByUserName(string userName)
        {
            var agreements = Database.Agreements
                .Find(a => a.UserName == userName)
                .OrderBy(a => a.IsConfirmd);

            var agreementDtos = Mapper.Map<IEnumerable<AgreementDto>>(agreements);

            return agreementDtos;
        }

        public IEnumerable<CarDeliveryDto> GetDeliveriesByAgreementId(int agreementId)
        {
            var deliveries = Database.CarDeliveries.Find(d => d.AgreementId == agreementId);

            var deliveryDtos = Mapper.Map<IEnumerable<CarDeliveryDto>>(deliveries);

            return deliveryDtos;
        }

        public IEnumerable<AgreementDto> GetAllAgreementsSortedByDate()
        {
            var agreements = Database.Agreements.GetAll().OrderByDescending(a => a.DateOfAgreement);

            var agreementDtos = Mapper.Map<IEnumerable<AgreementDto>>(agreements);

            return agreementDtos;
        }

        public AgreementDto GetAgreementDtoById(int id)
        {
            var agreement = Database.Agreements.Get(id);

            var agreementDto = Mapper.Map<AgreementDto>(agreement);

            return agreementDto;
        }

        public void UpdateAgreement(
            int agreementDtoId,
            bool isConfirmed,
            bool isDeleted,
            string managersComment,
            bool isPickUped,
            bool isReturned)
        {
            var agreement = Database.Agreements.Get(agreementDtoId);

            agreement.IsConfirmd = isConfirmed;
            agreement.IsDeleted = isDeleted;
            agreement.ManagerComment = managersComment;

            Database.Agreements.Update(agreement);

            var deliveries = Database.CarDeliveries.GetAll()
                .Where(cd => cd.AgreementId == agreementDtoId).ToList();

            var pickupDelivery = deliveries.SingleOrDefault(d => d.IsDeliveryToUser == true);
            pickupDelivery.IsDeleted = isDeleted;
            pickupDelivery.IsCompleted = isPickUped;
            Database.CarDeliveries.Update(pickupDelivery);

            var returnDelivery = deliveries.SingleOrDefault(d => d.IsDeliveryToUser == false);
            returnDelivery.IsDeleted = isDeleted;
            returnDelivery.IsCompleted = isReturned;
            Database.CarDeliveries.Update(returnDelivery);

            Database.Save();
        }
    }
}
