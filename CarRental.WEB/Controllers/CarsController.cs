using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.BLL.Models;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        private readonly IPlaceService placeService;

        private FileManager fileManager;

        public CarsController(ICarService servСar, IPlaceService servPlace)
        {
            carService = servСar;
            placeService = servPlace;
            fileManager = new FileManager();
        }

        [HttpGet]
        [Authorize(Roles = RoleName.NotBannedUsers)]
        public ActionResult SearchAvailableCarsByOptions(CarSearchViewModel carSearchViewModel)
        {
            CarSearchModel carSearchModel = Mapper.Map<CarSearchModel>(carSearchViewModel);

            var rentViewModel = carSearchViewModel.rentViewModel;

            var carDtos = carService.GetCarsByOptions(carSearchModel, rentViewModel.firstDayRent, rentViewModel.lastDayRent);

            var carViewModels = Mapper.Map<IEnumerable<CarViewModel>>(carDtos);

            //
            carSearchViewModel.CarViewModels = carViewModels;
            carSearchViewModel.BodyTypeDtos = carService.GetAllBodyTypeDtos();
            carSearchViewModel.CarClassDtos = carService.GetAllCarClassDtos();
            carSearchViewModel.FuelTypeDtos = carService.GetAllFuelTypeDtos();
            carSearchViewModel.GearboxTypeDtos = carService.GetAllGearboxTypeDtos();
            carSearchViewModel.ManufacturerDtos = carService.GetAllManufacturerDtos();
            carSearchViewModel.TransmissionTypeDtos = carService.GetAllTransmissionTypeDtos();

            var places = placeService.GetAll();
            carSearchViewModel.rentViewModel.Locations = places;
            carSearchViewModel.rentViewModel.PickUpLocation = places
                .SingleOrDefault(p => p.Id == carSearchViewModel.rentViewModel.PickUpLocationId);
            carSearchViewModel.rentViewModel.ReturnLocation = places
                .SingleOrDefault(p => p.Id == carSearchViewModel.rentViewModel.ReturnLocationId);

            return View("CarSearchView", carSearchViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.NotBannedUsers)]
        public ActionResult CarsAvailableForRent(RentViewModel rentViewModel)
        {
            //Добавить проверку по дате Аренды из rentViewModel
            var firstDayRent = rentViewModel.firstDayRent;
            var lastDayRent = rentViewModel.lastDayRent;


            var carDtos = carService.GetAvailableCarsForDates(rentViewModel.firstDayRent, rentViewModel.lastDayRent);
            var carViewModels = Mapper.Map<List<CarViewModel>>(carDtos);
           
            var bodyTypeDtos = carService.GetAllBodyTypeDtos();
            var carClassDtos = carService.GetAllCarClassDtos();
            var fuelTypeDtos = carService.GetAllFuelTypeDtos();
            var gearboxTypeDtos = carService.GetAllGearboxTypeDtos();
            var manufacturerDtos = carService.GetAllManufacturerDtos();
            var transmissionTypeDtos = carService.GetAllTransmissionTypeDtos();
            CarSearchViewModel carSearchViewModel = new CarSearchViewModel(
                carViewModels,
                bodyTypeDtos,
                carClassDtos,
                fuelTypeDtos,
                gearboxTypeDtos,
                manufacturerDtos,
                transmissionTypeDtos
                );
            var places = placeService.GetAll();
            rentViewModel.Locations = places;
            rentViewModel.PickUpLocation = places.SingleOrDefault(p => p.Id == rentViewModel.PickUpLocationId);
            rentViewModel.ReturnLocation = places.SingleOrDefault(p => p.Id == rentViewModel.ReturnLocationId);

            carSearchViewModel.rentViewModel = rentViewModel;
            
            return View("CarSearchView", carSearchViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var carDtos = carService.GetAllCars();
            var carViewModel = Mapper.Map<List<CarViewModel>>(carDtos);

            if(User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Manager))
                return View("List", carViewModel);
            else
                return View("ReadOnlyList", carViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int carDtoId)
        {
            var carDto = carService.Get(carDtoId);
            var carViewModel = Mapper.Map<CarViewModel>(carDto);
            
            var bodyTypeDtos = carService.GetAllBodyTypeDtos();
            var carClassDtos = carService.GetAllCarClassDtos();
            var fuelTypeDtos = carService.GetAllFuelTypeDtos();
            var gearboxTypeDtos = carService.GetAllGearboxTypeDtos();
            var manufacturerDtos = carService.GetAllManufacturerDtos();
            var transmissionTypeDtos = carService.GetAllTransmissionTypeDtos();

            var carFormViewModel = new CarFormViewModel(
                carViewModel,
                bodyTypeDtos,
                carClassDtos,
                fuelTypeDtos,
                gearboxTypeDtos,
                manufacturerDtos,
                transmissionTypeDtos
                );

            return View(carFormViewModel);
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult New()
        {
            var carViewModel = new CarViewModel();
            var bodyTypeDtos = carService.GetAllBodyTypeDtos();
            var carClassDtos = carService.GetAllCarClassDtos();
            var fuelTypeDtos = carService.GetAllFuelTypeDtos();
            var gearboxTypeDtos = carService.GetAllGearboxTypeDtos();
            var manufacturerDtos = carService.GetAllManufacturerDtos();
            var transmissionTypeDtos = carService.GetAllTransmissionTypeDtos();

            var carFormViewModel = new CarFormViewModel(
                carViewModel,
                bodyTypeDtos,
                carClassDtos,
                fuelTypeDtos,
                gearboxTypeDtos,
                manufacturerDtos,
                transmissionTypeDtos
                );

            return View("CarForm", carFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminAndManager)]
        public ActionResult Save(CarFormViewModel carFormViewModel)
        {
            var carDto = Mapper.Map<CarDto>(carFormViewModel.CarViewModel);

            if (!ModelState.IsValid)
            {
                var carViewModel = new CarViewModel();
                carFormViewModel.CarViewModel = carViewModel;
                return View("CarForm", carFormViewModel);
            }
            if (carDto.Id == 0)
            {
                var path = fileManager.GeneratePictureName("/Files/Cars/");
                carDto.PictureLink = path;
                carDto.IsAvailable = true;
                carService.Add(carDto);

                if (carFormViewModel.CarViewModel.Picture.Upload != null)
                {
                    carFormViewModel.CarViewModel.Picture.Upload
                        .SaveAs(Server.MapPath(path));
                }
            }
            else
            {
                var pictureLink = carDto.PictureLink;
                bool delete = true;
                if (pictureLink == null)
                {
                    carDto.PictureLink = fileManager.GeneratePictureName("/Files/Cars/");
                    delete = false;
                }

                carService.Edit(carDto);

                if (carFormViewModel.CarViewModel.Picture.Upload != null)
                {
                    if (delete)
                    {
                        var pathToPicture = Server.MapPath(pictureLink);
                        if (fileManager.FileExists(pathToPicture))
                        {
                            fileManager.Delete(pathToPicture);
                        }
                    }
                    carFormViewModel.CarViewModel.Picture.Upload
                        .SaveAs(Server.MapPath(pictureLink));
                }
            }
            return RedirectToAction("Index", "Cars");
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult Edit(int carDtoId)
        {
            var carDto = carService.Get(carDtoId);

            if (carDto == null)
                return HttpNotFound();

            var carViewModel = Mapper.Map<CarViewModel>(carDto);

            var bodyTypeDtos = carService.GetAllBodyTypeDtos();
            var carClassDtos = carService.GetAllCarClassDtos();
            var fuelTypeDtos = carService.GetAllFuelTypeDtos();
            var gearboxTypeDtos = carService.GetAllGearboxTypeDtos();
            var manufacturerDtos = carService.GetAllManufacturerDtos();
            var transmissionTypeDtos = carService.GetAllTransmissionTypeDtos();

            var carFormViewModel = new CarFormViewModel(
                carViewModel,
                bodyTypeDtos,
                carClassDtos,
                fuelTypeDtos,
                gearboxTypeDtos,
                manufacturerDtos,
                transmissionTypeDtos
                );

            return View("CarForm", carFormViewModel);
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult Delete(int carDtoId)
        {
            carService.MarkAsDeleted(carDtoId);

            return RedirectToAction("Index", "Car");
        }
    }
}