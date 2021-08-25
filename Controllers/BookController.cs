using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using LibaryManagementSystem2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static LibaryManagementSystem2.Models.ViewModels.AddBookViewModel;

namespace LibaryManagementSystem2.Controllers
{

    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

         public BookController(IBookService bookService,  ICategoryService categoryService, IUserService userService)
        {
            _bookService = bookService;
        
            _categoryService = categoryService;
            _userService = userService;
        }
         public IActionResult Index()
        {
             var books = _bookService.GetAll();
              List<ListBookViewModel> ListBooks = new List<ListBookViewModel>();

            foreach (var book in books)
            {
               

                ListBookViewModel listBookViewModel = new ListBookViewModel
                {

                    Id = book.BookId,
                    Name = book.Name,
                    NumberOfItem = book.NumberOfItem,
                    RackNumber = book.RackNumber,
                    CategoryId = book.CategoryId,
                    MaxIssueDays = book.MaxIssueDays,
                };

                ListBooks.Add(listBookViewModel);
            }
              int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User userlogin = _userService.FindById(userId);
            ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

            return View(ListBooks);

          
        }
          public IActionResult AddBook(AddBookViewModel addBook)
        {
           
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Book book = new Book
            {
                Name = addBook.Name,
                RackNumber = addBook.RackNumber,
                NumberOfItem = addBook.NumberOfItem,
                CategoryId = addBook.CategoryId,
                MaxIssueDays = addBook.MaxIssueDays,

            };

            _bookService.AddBook(book);
            return RedirectToAction("Index");
        }
        
         public IActionResult UpdateBook(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User userlogin = _userService.FindById(userId);
                ViewBag.UserName = $"{userlogin.FirstName} .{userlogin.LastName[0]}";

                UpdateBookViewModel updateBook = new UpdateBookViewModel
                {
                    Id = book.BookId,
                    Name = book.Name,
                    NumberOfItem = book.NumberOfItem,
                    CategoryId = book.CategoryId,
                    MaxIssueDays = book.MaxIssueDays,
                    BookItemId = book.BookItemId,
                    FlockList = _flockService.GetAllFlocks().Select(m => new SelectListItem
                    {
                        Text = $"{_flockTypeService.FindById(m.FlockTypeId).Name} Batch No: {m.BatchNo}",
                        Value = m.Id.ToString(),
                    }),
                };

                return View(updateStock);
            }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                if(book != null)
                {
                    
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
                }
            }
            return View(book);
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _bookService.GetBook(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
           [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
          public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _bookService.GetBook(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
           [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }


    }
}


