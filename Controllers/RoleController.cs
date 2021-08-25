using Microsoft.AspNetCore.Mvc;
using LibaryManagementSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibaryManagementSystem2.Interfaces;
using System.Security.Claims;
using LibaryManagementSystem2.Models.ViewModels;

namespace SimpleAuthentication.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View();
        }

        public IActionResult AddRole()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View();
        }

        [HttpPost]
        public IActionResult AddRole(AddRoleViewModel addRole)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Role role = new Role
            {
                UserId = userId,
                RoleName = addRole.Name,
            };

            _roleService.Add(role);
            return RedirectToAction("ListRole");
        }

        public IActionResult ListRole()
        {
            var roles = _roleService.GetAllRoles();
            List<ListRoleViewModel> ListRole = new List<ListRoleViewModel>();

            foreach (var role in roles)
            {
                ListRoleViewModel listRoleViewModel = new ListRoleViewModel
                {

                    Id = role.Id,
                    Name = role.RoleName,
                    UserId = role.UserId,
                  
                };

                ListRole.Add(listRoleViewModel);
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListRole);
        }

        public IActionResult UpdateRole(int id)
        {
            var role = _roleService.FindById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateRoleViewModel updateRole = new UpdateRoleViewModel
                {
                    Name = role.RoleName,
                    Id = role.Id,
                };

                return View(updateRole);
            }
           
        }

        [HttpPost]
        public IActionResult UpdateRole(UpdateRoleViewModel updateRole)
        {
            Role role = new Role
            {
                Id = updateRole.Id,
                RoleName = updateRole.Name,
            };
            _roleService.Update(role);
            return RedirectToAction("ListRole");
        }



        public IActionResult Delete(int id)
        {
            var role = _roleService.FindById(id);
            if (role == null)
            {
                return NotFound();
            }
            _roleService.Delete(id);
            return RedirectToAction("ListRole");
        }
    }
}
        
