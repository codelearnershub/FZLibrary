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
    public class BookItemController : Controller
    {
        private readonly IBookItemService _bookItemService;
        private readonly IUserService _userService;
         private readonly IBookService _bookService;
           public BookItemController(IBookItemService bookItemService,  IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
        
            _bookItemService = bookItemService;
            _userService = userService;
        }
          public IActionResult Index()
         private readonly IBookItemService _bookItemService;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public BookItemController(IBookItemService bookItemService, IUserService userService, IBookService bookService)
        {
            _bookItemService = bookItemService;
            _userService = userService;
            _bookService = bookService;

        }

        public IActionResult Index()
        {

            var bookItems = _bookItemService.GetAll();
            List<ListBookItemViewModel> ListBookItem = new List<ListBookItemViewModel>();

            foreach (var bookItem in bookItems)
            {
               

                ListBookItemViewModel listBookItemViewModel = new ListBookItemViewModel
                {

                    Id = bookItem.Id,
                    Barcode = bookItem.Barcode,
                    BookId = bookItem.BookId,
                    NumberOfItem = bookItem.NumberOfItem,
                    FineAmount = bookItem.FineAmount,
                    ItemsRemaining = bookItem.ItemsRemaining,
                    CreatedAt = bookItem.CreatedAt,
                    BookList = _bookService.GetAll().Select(m => new SelectListItem
                    {
                        Text = $"{_bookService.GetBook(m.BookId).Name} ",
                        Value = m.BookId.ToString(),
                    })
                };

                ListBookItem.Add(listBookItemViewModel);
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListBookItem);
        }

        public IActionResult AddStoreItem()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View();
        }

        [HttpPost]
        public IActionResult AddBookItem(AddBookItemViewModel addBookItem)
        {
            BookItem bookItem = new BookItem
            {
                BookId = addBookItem.BookId,
                NumberOfItem = addBookItem.NumberOfItem,
                Barcode = addBookItem.Barcode,
                FineAmount = addBookItem.FineAmount,
                ItemsRemaining = addBookItem.NumberOfItem,
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            BookItem bookItem = new BookItem
            {
                Id = addBookItem.Id,
                Barcode = addBookItem.Barcode,
                NumberOfItem = addBookItem.NumberOfItem,
                CreatedAt = DateTime.Now,
            };

            _bookItemService.Add(bookItem);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateBookItem(int id)
        {
            var bookItem = _bookItemService.FindById(id);
            if (bookItem == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateBookItemViewModel updateBookItem = new UpdateBookItemViewModel
                {
                    Id = bookItem.Id,
                    NumberOfItem = bookItem.NumberOfItem,
                    BookId = bookItem.BookId,
                    Barcode = bookItem.Barcode,
                    FineAmount = bookItem.FineAmount,
                    Id = bookItem.Id,
                    Barcode = bookItem.Barcode,
                    NumberOfItem = bookItem.NumberOfItem,
                    CreatedAt = DateTime.Now,
                };

                return View(updateBookItem);
            }

        }

        [HttpPost]
        public IActionResult UpdateBookItem(UpdateBookItemViewModel updateBookItem)
        {
            BookItem bookItem = new BookItem
            {
                Id = updateBookItem.Id,
                Barcode = updateBookItem.Barcode,
                NumberOfItem = updateBookItem.NumberOfItem,
                BookId = updateBookItem.BookId,
                FineAmount = updateBookItem.FineAmount,
                ItemsRemaining = updateBookItem.NumberOfItem,
                Id = updateBookItem.Id,
                Barcode = updateBookItem.Barcode,
                NumberOfItem = updateBookItem.NumberOfItem,
                CreatedAt = DateTime.Now,
            };
            _bookItemService.Update(bookItem);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var bookItem = _bookItemService.FindById(id);
            if (bookItem == null)
            var storeItem = _bookItemService.FindById(id);
            if (storeItem == null)
            {
                return NotFound();
            }
            _bookItemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}