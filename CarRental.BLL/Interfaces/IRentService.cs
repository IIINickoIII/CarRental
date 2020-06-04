using CarRental.BLL.Dto;
using System.Collections.Generic;

namespace CarRental.BLL.Interfaces
{
    public interface IRentService
    {
        int AddAgreement(AgreementDto agreementDto);

        void AddCarDelivery(CarDeliveryDto carDeliveryDto);

        void UpdateAgreement(int agreementDtoId, bool isConfirmed, bool isDeleted, string managersComment, bool isPickUped, bool isReturned);

        AgreementDto GetAgreementDtoById(int id);

        IEnumerable<AgreementDto> GetAgreementsByUserName(string userName);

        IEnumerable<CarDeliveryDto> GetDeliveriesByAgreementId(int agreementId);

        IEnumerable<AgreementDto> GetAllAgreementsSortedByDate();
    }
}
