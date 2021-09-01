using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using LibaryManagementSystem2.Models.ViewModels;
using LibaryManagementSystem2.Repositories;
using LibaryManagementSystem2.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace LibaryManagementSystem.Controllers
 {


     public class UserController : Controller
     {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {

            return View();
        }
            
        [HttpGet]
         [AllowAnonymous]
         public IActionResult RegisterUser()
        {
            RegisterUserViewModel registerVM = new RegisterUserViewModel
            {
                RoleList = _roleService.GetAllRoles().Select(m => new SelectListItem
                {
                    Text = m.RoleName,
                    Value = m.Id.ToString()
                })
            };

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(registerVM);
        }


        [HttpPost]
        public IActionResult RegisterUser(RegisterUserViewModel vm)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            User user = new User
            {
                 Id = userId,
                Email = vm.Email,
                Password = vm.Password,
                LastName = vm.LastName,
                FirstName = vm.FirstName,
                PhoneNumber = vm.PhoneNumber,
                Address = vm.Address,
                RoleId = vm.RoleId,
            };
            _userService.RegisterUser(user);
            return RedirectToAction("ListUser");
        }


     }
 }
       
