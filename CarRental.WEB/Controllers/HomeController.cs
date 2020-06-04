using AutoMapper;
using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceService placeService;

        private readonly IRentService rentService;

        public HomeController(IPlaceService servPlace, IRentService servRent)
        {
            placeService = servPlace;
            rentService = servRent;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            //throw new System.Exception("Let's log an exception!");

            var places = placeService.GetAll();
            var rentViewModel = new RentViewModel();
            rentViewModel.Locations = places;

            return View(rentViewModel);
        }

        [Authorize(Roles = RoleName.AllRoles)]
        [HttpGet]
        public ActionResult MyAgreements()
        {
            var agreementDtos = rentService.GetAgreementsByUserName(User.Identity.Name);
            List<AgreementViewModel> agreementViewModels = new List<AgreementViewModel>();

            foreach (var agreementDto in agreementDtos)
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


            return View(agreementViewModels);
        }

        [Authorize(Roles = RoleName.AllRoles)]
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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}