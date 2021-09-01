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
    public class FineController : Controller
    {
         private readonly IBookService _bookService;
         private readonly IFineService _fineService;
         private readonly IUserService _userService;
         
        public FineController(IFineService fineService, IBookService bookService, IUserService userService)
        {
            _fineService = fineService;
            _bookService = bookService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var fines = _fineService.GetAll();
            List<ListFineViewModel> ListFines = new List<ListFineViewModel>();

            foreach (var fine in fines)
            {
               
                ListFineViewModel listFineViewModel = new ListFineViewModel
                {

                    Id = fine.Id,
                    Amount = fine.FineAmount,
                    UserId = fine.UserId,
                    BookItemId = fine.BookItemId,
                   
                };

                ListFines.Add(listFineViewModel);
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListFines);

        }

        public IActionResult AddFines()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View();
        }

        [HttpPost]
        public IActionResult AddFines(AddFineViewModel addFines)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Fine fine = new Fine
            {
            
                UserId = userId,
                FineAmount = addFines.FineAmount,
                BookItemId = addFines.BookItemId,
            };

            _fineService.Add(fine);
            return RedirectToAction("ListRole");
        }


        public IActionResult UpdateFine(int id)
        {
            var fine = _fineService.FindById(id);
            if (fine == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateFineViewModel updateFine = new UpdateFineViewModel
                {
                    FineAmount = fine.FineAmount,
                    
                };

                return View(updateFine);
            }

        }

        [HttpPost]
        public IActionResult UpdateFine(UpdateFineViewModel updateFines)
        {
            Fine fine = new Fine
            {
                Id = updateFines.Id,
                FineAmount = updateFines.FineAmount,
            };
            _fineService.Update(fine);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var fine = _fineService.FindById(id);
            if (fine == null)
            {
                return NotFound();
            }
            _fineService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}