using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using LibaryManagementSystem2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibaryManagementSystem2.Controllers
{
    public class SuperAdminController : Controller
    {
          private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;

        public SuperAdminController(IUserService userService, IUserRoleService userRoleService, IRoleService roleService)
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

        public IActionResult ListUser()
        {
            var users = _userService.GetAllUser();
            List<ListUserViewModel> ListUser = new List<ListUserViewModel>();

            foreach (var user in users)
            {
               

                ListUserViewModel listUserViewModel = new ListUserViewModel
                {

                    UserId = user.Id,
                    FullName = $"{user.LastName} {user.FirstName}",
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RoleName = _userRoleService.FindRole(user.Id),
                   

                };

                ListUser.Add(listUserViewModel);
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListUser);
        }


        public IActionResult UpdateUser(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateUserViewModel updateUser = new UpdateUserViewModel
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    RoleId = _userRoleService.FindUserRole(user.Id).RoleId,
                    RoleList = _roleService.GetAllRoles().Select(m => new SelectListItem
                    {
                        Text = m.RoleName,
                        Value = m.Id.ToString()
                    })
                };

                return View(updateUser);
            }

        }

        [HttpPost]
        public IActionResult UpdateUser(UpdateUserViewModel updateUser)
        {
            User user = new User
            {
                Id = updateUser.Id,
                LastName = updateUser.LastName,
                FirstName = updateUser.FirstName,
                PhoneNumber = updateUser.PhoneNumber,
                Email = updateUser.Email,
                Password = updateUser.Password,
                Address = updateUser.Address,
                RoleId = updateUser.RoleId,
            };
            _userService.Update(user);
            return RedirectToAction("ListUser");
        }


        public IActionResult Delete(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Delete(id);
            return RedirectToAction("ListUser");
        } 
    }
}