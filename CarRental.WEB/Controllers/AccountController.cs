﻿using CarRental.BLL.Dto;
using CarRental.BLL.Infrastructure;
using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using CarRental.WEB.ViewModels.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    RoleId = "User"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult ChangeRole(ChangeRoleViewModel changeRoleModel)
        {
            var userId = changeRoleModel.userDto.Id;
            var roleModel = UserService.GetRole(changeRoleModel.userDto.RoleId);
            try
            {
                UserService.ChangeRole(userId,
                    new RoleDto
                    {
                        Name = roleModel.Name
                    });
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return RedirectToAction("GetUsers");
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpGet]
        public ActionResult GetUsers()
        {
            var usersViewModel = new UsersViewModel();
            usersViewModel.UserDtos = UserService.GetAllUsers();
            usersViewModel.RoleDtos = UserService.GetRoles();

            return View(usersViewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpGet]
        public ActionResult GetUser(string userId)
        {
            UserDto user;
            try
            {
                user = UserService.GetUser(userId);
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            var principal = HttpContext.User;
            if (principal.IsInRole(RoleName.Admin))
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Address = user.Address,
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    RoleId = user.RoleId
                };

                var roleDtos = UserService.GetRoles();

                var viewModel = new ChangeRoleViewModel();
                viewModel.userDto = userDto;
                viewModel.roleDtos = roleDtos;

                return View(viewModel);
            }
            else
            {
                return View();
            }
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(
                new List<UserDto>
                {
                    new UserDto
                    {
                        Email = "admin@carrental.com",
                        UserName = "admin@carrental.com",
                        Password = "123456",
                        Name = "Nicko",
                        Address = "Ukraine, Kharkov, 23 Serpnya st., 43",
                        RoleId = RoleName.Admin,
                    },
                    new UserDto
                    {
                        Email = "manager@carrental.com",
                        UserName = "manager@carrental.com",
                        Password = "123456",
                        Name = "Alex",
                        Address = "Ukraine, Kharkov, Heroiv Pratsi, 7",
                        RoleId = RoleName.Manager,
                    },
                    new UserDto
                    {
                        Email = "user@carrental.com",
                        UserName = "user@carrental.com",
                        Password = "123456",
                        Name = "John",
                        Address = "Ukraine, Kharkov, 23 Serpnya st., 44",
                        RoleId = RoleName.User,
                    }
                },
                new List<string>
                {
                    "Admin",
                    "Manager",
                    "User"
                });
        }
    }
}