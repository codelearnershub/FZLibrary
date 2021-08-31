using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using LibaryManagementSystem2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibaryManagementSystem2.Controllers
{ 
    public class RackController : Controller
    {
           private readonly IBookItemService _bookItemService;
           private readonly IRackService _rackService;
           private readonly IUserService _userService;
         
        public RackController(IRackService rackService,  IBookItemService bookItemService, IUserService userService)
        {      
            _rackService = rackService;
            _bookItemService = bookItemService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var racks = _rackService.GetAll();
            List<ListRackViewModel> ListRacks = new List<ListRackViewModel>();

            foreach (var rack in racks)
            {
               
                ListRackViewModel listRackViewModel = new ListRackViewModel
                {
                    RackNumber = rack.RackNumber,
                    Location = rack.Location,                   
                };

                ListRacks.Add(listRackViewModel);
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListRacks);

        }

        public IActionResult AddRack()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View();
        }

        [HttpPost]
        public IActionResult AddRack(AddRackViewModel addRack)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Rack rack = new Rack
            {
                RackNumber = addRack.RackNumber,
                Location = addRack.Location,
            
            };

            _rackService.Add(rack);
            return RedirectToAction("ListRole");
        }


        public IActionResult UpdateRack(int id)
        {
            var rack = _rackService.FindById(id);
            if (rack == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateRackViewModel updateRack = new UpdateRackViewModel
                {
                    RackNumber = rack.RackNumber,
                    Location = rack.Location,
                    
                };

                return View(updateRack);
            }

        }

        [HttpPost]
        public IActionResult UpdateRack(UpdateRackViewModel updateRack)
        {
            Rack rack = new Rack
            {
                RackNumber = updateRack.RackNumber,
                Location = updateRack.Location,
               
            };
            _rackService.Update(rack);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var rack = _rackService.FindById(id);
            if (rack == null)
            {
                return NotFound();
            }
            _rackService.Delete(id);
            return RedirectToAction("Index");
        } 
    
    }
  
}