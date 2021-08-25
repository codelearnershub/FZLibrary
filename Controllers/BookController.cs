using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                    CategoryList = _categoryService.GetAll().Select(m => new SelectListItem
                    {
                        Text = $"{_categoryService.FindById(m.Id).Name} ",
                        Value = m.Id.ToString(),
                    }),
                };

                return View(updateBook);
            }
        }

        [HttpPost]
        public IActionResult UpdateBook(UpdateBookViewModel updateBook)
        {
            Book book = new Book
            {
                BookId = updateBook.Id,
                Name = updateBook.Name,
                NumberOfItem = updateBook.NumberOfItem,
                CategoryId = updateBook.CategoryId,
                RackNumber = updateBook.RackNumber,
                MaxIssueDays = updateBook.MaxIssueDays,
                BookItemId = updateBook.BookItemId,
            };
            _bookService.UpdateBook(book);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

         
    }
}


