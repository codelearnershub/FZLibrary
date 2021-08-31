// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Claims;
// using LibaryManagementSystem2.Interfaces;
// using LibaryManagementSystem2.Models;
// using LibaryManagementSystem2.Models.ViewModels;
// using Microsoft.AspNetCore.Mvc;

// namespace LibaryManagementSystem2.Controllers
// {
//     public class LendingController
//     {
//         private readonly ILendingService _lendingService;
//          private readonly IUserService _userService;
         
//         public LendingController(ILendingService lendingService,  IUserService userService)
//         {
            
//             _lendingService = lendingService;
//             _userService = userService;
//         }

//         public IActionResult Index()
//         {
//             var lending = _lendingService.GetAll();
//             List<ListLendingViewModel> ListLendings = new List<ListLendingViewModel>();

//             foreach (var lend in lending)
//             {
               
//                 ListLendingViewModel listLendingViewModel = new ListLendingViewModel
//                 {

//                     Id = lend.Id,
//                     UserId = lend.UserId,
//                     BookItemId = lend.BookItemId,
//                     IsReturned = lend.IsReturned,
//                     IssueDate = lend.IssueDate,
//                     ExpireDate = lend.ExpireDate,
                   
//                 };

//                 ListLendings.Add(listLendingViewModel);
//             }

//             int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
//             User userlogin = _userService.FindById(userId);
//             ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

//             return View(ListLendings);

//         }

//         public IActionResult AddLendings()
//         {
//             int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
//             User userlogin = _userService.FindById(userId);
//             ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

//             return View();
//         }

//         [HttpPost]
//         public IActionResult AddLendings(AddLendingViewModel addLendings)
//         {
//             int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//             Lending Lending = new Lending
//             {
            
//                 UserId = userId,
//                 BookItemId = addLendings.BookItemId,
//                 IsReturned = addLendings.IsReturned,
//                 IssueDate = addLendings.IssueDate,
//                 ExpireDate = addLendings.ExpireDate,
//             };

//             _lendingService.Add(Lending);
//             return RedirectToAction("ListRole");
//         }


//         public IActionResult UpdateLending(int id)
//         {
//             var lending = _lendingService.FindById(id);
//             if (lending == null)
//             {
//                 return NotFound();
//             }
//             else
//             {
//                 int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
//                 User userlogin = _userService.FindById(userId);
//                 ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

//                 UpdateLendingViewModel updateLending = new UpdateLendingViewModel
//                 {
//                     Id = lend.Id,
//                     UserId = lend.UserId,
//                     BookItemId = lend.BookItemId,
//                     IsReturned = lend.IsReturned,
//                     IssueDate = lend.IssueDate,
//                     ExpireDate = lend.ExpireDate,
                    
//                 };

//                 return View(updateLending);
//             }

//         }

//         [HttpPost]
//         public IActionResult UpdateLending(UpdateLendingViewModel updateLendings)
//         {
//             Lending lending = new Lending
//             {
//                 UserId = userId,
//                 BookItemId = updateLendings.BookItemId,
//                 IsReturned = updateLendings.IsReturned,
//                 IssueDate = updateLendings.IssueDate,
//                 ExpireDate = updateLendings.ExpireDate,
//             };
//             _lendingService.Update(lending);
//             return RedirectToAction("Index");
//         }



//         public IActionResult Delete(int id)
//         {
//             var lending = _lendingService.FindById(id);
//             if (lending == null)
//             {
//                 return NotFound();
//             }
//             _lendingService.Delete(id);
//             return RedirectToAction("Index");
//         } 
//     }
// }