using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    public class RentsController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        ICarService carService;

        IRentService rentService;

        IPlaceService placeService;

        IManufacturerService manufacurerService;

        public RentsController(ICarService servCar, IPlaceService servPlace, IManufacturerService servMan, IRentService servRent)
        {
            carService = servCar;
            rentService = servRent;
            placeService = servPlace;
            manufacurerService = servMan;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.NotBannedUsers)]
        public ActionResult SearchForAvailableCars(RentViewModel rentViewModel)
        {
            return RedirectToAction("CarsAvailableForRent", "Cars", rentViewModel);
        }

        [Authorize(Roles = RoleName.NotBannedUsers)]
        [HttpGet]
        public ActionResult RentCar(int CarDtoId, DateTime firstDayRent, DateTime lastDayRent, int PickUpLocationId, int ReturnLocationId)
        {
            var carDto = carService.Get(CarDtoId);
            carDto.ManufacturerDto = manufacurerService.Get(carDto.ManufacturerId);
            var numberOfDaysInRent = NumberOfDaysInRent(firstDayRent, lastDayRent);
            var rentViewModel = new RentViewModel()
            {
                firstDayRent = firstDayRent,
                lastDayRent = lastDayRent,
                PickUpLocationId = PickUpLocationId,
                ReturnLocationId = ReturnLocationId,
                Locations = placeService.GetAll()
            };
            var agreementViewModel = new AgreementViewModel()
            {
                CarDto = carDto,
                CarId = CarDtoId,
                UserName = User.Identity.Name,
                NumberOfDays = numberOfDaysInRent,
                TotalPrice = numberOfDaysInRent * carDto.PricePerDay,
                DateOfAgreement = DateTime.Now,
                rentViewModel = rentViewModel
            };

            return View("RentForm", agreementViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.NotBannedUsers)]
        public ActionResult Save(AgreementViewModel agreementVieModel)
        {
            var rentViewModel = agreementVieModel.rentViewModel;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("RentCar", new
                {
                    CarDtoId = agreementVieModel.CarId,
                    firstDayRent = rentViewModel.firstDayRent,
                    lastDayRent = rentViewModel.lastDayRent,
                    PickUpLocationId = rentViewModel.PickUpLocationId,
                    ReturnLocationId = rentViewModel.ReturnLocationId
                });
            }
            var agreementDto = Mapper.Map<AgreementDto>(agreementVieModel);

            if (agreementDto.WithDriver)
            {
                agreementDto.TotalPrice += 50 * agreementDto.NumberOfDays;
            }

            switch (agreementDto.InsuranceType)
            {
                case InsuranceType.Standard:
                    {
                        double percent = agreementDto.TotalPrice * 0.05;

                        percent = percent - percent % 1;

                        try
                        {
                            agreementDto.TotalPrice = checked(agreementDto.TotalPrice + (int)percent);
                        }
                        catch(OverflowException ex)
                        {
                            // logging
                            agreementDto.TotalPrice = int.MaxValue;
                        }

                        break;
                    }
                case InsuranceType.Lux:
                    {
                        double percent = agreementDto.TotalPrice * 0.10;

                        percent = percent - percent % 1;

                        try
                        {
                            agreementDto.TotalPrice = checked(agreementDto.TotalPrice + (int)percent);
                        }
                        catch (OverflowException ex)
                        {
                            // logging
                            agreementDto.TotalPrice = int.MaxValue;
                        }

                        break;
                    }
            }

            agreementDto.IsPayed = true;

            var id = rentService.AddAgreement(agreementDto);

            var pickUpCarDelivery = new CarDeliveryDto()
            {
                AgreementId = id,
                DateOfDelivery = rentViewModel.firstDayRent,
                IsDeliveryToUser = true,
                NoDamage = true,
                PlaceId = rentViewModel.PickUpLocationId,
                CarId = agreementVieModel.CarId
            };

            rentService.AddCarDelivery(pickUpCarDelivery);

            var returnCarDelivery = new CarDeliveryDto()
            {
                AgreementId = id,
                DateOfDelivery = rentViewModel.lastDayRent,
                IsDeliveryToUser = false,
                NoDamage = false,
                PlaceId = rentViewModel.ReturnLocationId,
                CarId = agreementVieModel.CarId
            };

            rentService.AddCarDelivery(returnCarDelivery);

            return RedirectToAction("Result");
        }

        private int NumberOfDaysInRent(DateTime firstDayRent, DateTime lastDayRent)
        {
            int days = (lastDayRent.Date - firstDayRent.Date).Days + 1;
            return days;
        }

        [Authorize(Roles = RoleName.NotBannedUsers)]
        [HttpGet]
        public ActionResult Result()
        {
            return View("ConfirmationPage");
        }
    }
}