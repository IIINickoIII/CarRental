using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Infrastructure;
using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    [Authorize(Roles = RoleName.AdminAndManager)]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService manufacturerService;

        private FileManager fileManager;

        public ManufacturersController(IManufacturerService serv)
        {
            manufacturerService = serv;
            fileManager = new FileManager();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var manufacturerDtos = manufacturerService.GetAll();
            var manufacturerViewModel = Mapper.Map<IEnumerable<ManufacturerViewModel>>(manufacturerDtos);

            if (User.IsInRole(RoleName.Admin) || User.IsInRole(RoleName.Manager))
                return View("List", manufacturerViewModel);
            else
                return View("ReadOnlyList", manufacturerViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int manufacturerDtoId)
        {
            var manufacturerDto = manufacturerService.Get(manufacturerDtoId);
            var manufacturerViewModel = Mapper.Map<ManufacturerViewModel>(manufacturerDto);

            return View(manufacturerViewModel);
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult New()
        {
            var manufacturerViewModel = new ManufacturerViewModel();

            return View("ManufacturerForm", manufacturerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminAndManager)]
        public async Task<ActionResult> Save(ManufacturerViewModel manufacturerViewModel)
        {
            var manufacturerDto = Mapper.Map<ManufacturerDto>(manufacturerViewModel);

            if (!ModelState.IsValid)
            {
                manufacturerViewModel = new ManufacturerViewModel();
                return View("ManufacturerForm", manufacturerViewModel);
            }
            if (manufacturerDto.Id == 0)
            {
                var path = fileManager.GeneratePictureName("/Files/Logo/");
                manufacturerDto.PictureLink = path;

                OperationDetails operationDetails = await manufacturerService.AddAsync(manufacturerDto);

                if (operationDetails.Succedeed)
                {
                    if (manufacturerViewModel.Picture.Upload != null)
                    {
                        manufacturerViewModel.Picture.Upload
                            .SaveAs(Server.MapPath(path));
                    }
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                    return View("ManufacturerForm", manufacturerViewModel);
                }
            }
            else
            {
                var pictureLink = manufacturerDto.PictureLink;
                bool delete = true;
                if (pictureLink == null)
                {
                    manufacturerDto.PictureLink = fileManager.GeneratePictureName("/Files/Logo/");
                    delete = false;
                }

                OperationDetails operationDetails = await manufacturerService.EditAcync(manufacturerDto);

                if (operationDetails.Succedeed)
                {
                    if (manufacturerViewModel.Picture.Upload != null)
                    {
                        if (delete)
                        {
                            var pathToPicture = Server.MapPath(pictureLink);
                            if (fileManager.FileExists(pathToPicture))
                            {
                                fileManager.Delete(pathToPicture);
                            }
                        }
                        manufacturerViewModel.Picture.Upload
                                .SaveAs(Server.MapPath(pictureLink));
                    }
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                    return View("ManufacturerForm", manufacturerViewModel);

                }
            }
            return RedirectToAction("Index", "Manufacturers");
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult Edit(int manufacturerDtoId)
        {
            //try catch (if manufacturerDto == 0) ...
            var manufacturerDto = manufacturerService.Get(manufacturerDtoId);

            if (manufacturerDto == null)
                return HttpNotFound();

            var manufacturerViewModel = Mapper.Map<ManufacturerViewModel>(manufacturerDto);

            return View("ManufacturerForm", manufacturerViewModel);
        }

        [Authorize(Roles = RoleName.AdminAndManager)]
        [HttpGet]
        public ActionResult Delete(int manufacturerDtoId)
        {
            manufacturerService.MarkAsDeleted(manufacturerDtoId);

            return RedirectToAction("Index", "Manufacturers");
        }
    }
}