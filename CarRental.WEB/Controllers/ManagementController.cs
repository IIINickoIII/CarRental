using AutoMapper;
using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    [Authorize(Roles = RoleName.AdminAndManager)]
    public class ManagementController : Controller
    {
        ICarService carService;

        IRentService rentService;

        IPlaceService placeService;

        IManufacturerService manufacurerService;

        public ManagementController(ICarService servCar, IPlaceService servPlace, IManufacturerService servMan, IRentService servRent)
        {
            carService = servCar;
            rentService = servRent;
            placeService = servPlace;
            manufacurerService = servMan;
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult AllAgreements()
        {
            var agreementDtos = rentService.GetAllAgreementsSortedByDate();
            List<AgreementViewModel> agreementViewModels = new List<AgreementViewModel>();

            foreach(var agreementDto in agreementDtos)
            {
                var agreementViewModel = Mapper.Map<AgreementViewModel>(agreementDto);
                    agreementViewModel.rentViewModel = new RentViewModel();
                var deliveryDtos = rentService.GetDeliveriesByAgreementId(agreementDto.Id);

                var deliveryPickUp = deliveryDtos.SingleOrDefault(d => d.IsDeliveryToUser == true);
                var deliveryReturn = deliveryDtos.SingleOrDefault(d => d.IsDeliveryToUser == false);

                agreementViewModel.rentViewModel.firstDayRent = deliveryPickUp.DateOfDelivery;
                agreementViewModel.rentViewModel.PickUpLocationId = deliveryPickUp.PlaceId;
                agreementViewModel.IsPickUped = deliveryPickUp.IsCompleted;

                agreementViewModel.rentViewModel.lastDayRent = deliveryReturn.DateOfDelivery;
                agreementViewModel.rentViewModel.ReturnLocationId = deliveryReturn.PlaceId;
                agreementViewModel.IsReturned = deliveryReturn.IsCompleted;

                agreementViewModels.Add(agreementViewModel);
            }

            return View("AgreementsList", agreementViewModels);
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult Details(int agreementDtoId)
        {
            var agreementDto = rentService.GetAgreementDtoById(agreementDtoId);

            var agreementViewModel = Mapper.Map<AgreementViewModel>(agreementDto);
                agreementViewModel.rentViewModel = new RentViewModel();

            var deliveryDtos = rentService.GetDeliveriesByAgreementId(agreementDtoId);

            var deliveryPickUp = deliveryDtos.SingleOrDefault(d => d.IsDeliveryToUser == true);
            var deliveryReturn = deliveryDtos.SingleOrDefault(d => d.IsDeliveryToUser == false);

            agreementViewModel.rentViewModel.firstDayRent = deliveryPickUp.DateOfDelivery;
            agreementViewModel.rentViewModel.PickUpLocationId = deliveryPickUp.PlaceId;
            agreementViewModel.IsPickUped = deliveryPickUp.IsCompleted;

            agreementViewModel.rentViewModel.lastDayRent = deliveryReturn.DateOfDelivery;
            agreementViewModel.rentViewModel.ReturnLocationId = deliveryReturn.PlaceId;
            agreementViewModel.IsReturned = deliveryReturn.IsCompleted;

            agreementViewModel.rentViewModel.Locations = placeService.GetAll();

            return View("Details", agreementViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminAndManager)]
        public ActionResult Save(AgreementViewModel agreementViewModel)
        {
            var agreementId = agreementViewModel.Id;
            var isConfirmed = agreementViewModel.IsConfirmd;
            var isDeleted = agreementViewModel.IsDeleted;
            var managersComment = agreementViewModel.ManagerComment;
            var isPickUped = agreementViewModel.IsPickUped;
            var isReturned = agreementViewModel.IsReturned;

            rentService.UpdateAgreement(agreementId, isConfirmed, isDeleted, managersComment, isPickUped, isReturned);

            return RedirectToAction("Details", routeValues: new { agreementDtoId = agreementId });
        }
    }
}