using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class BookItemService
    {
          private readonly IBookItemRepository _bookItemRepository;
        private readonly IUserService _userService;

        public BookItemService(IBookItemRepository bookItemRepository, IUserService userService)
        {
            _bookItemRepository = bookItemRepository;
            _userService = userService;
        }

        public BookItem Add(BookItem bookItem)
        {
            var booksItem = new BookItem
            {
              
                CreatedAt = DateTime.Now,
                BookId = bookItem.BookId,
                Barcode = (Guid.NewGuid()).ToString("0000000000"),
                NumberOfItem = bookItem.NumberOfItem,
                
            };

            return _bookItemRepository.Add(bookItem);
        }

        public BookItem FindById(int id)
        {
            return _bookItemRepository.FindById(id);
        }

        public BookItem Update(int bookItemId, BookItem bookItem)
        {
            var booksItem = _bookItemRepository.FindById(bookItemId);
            if (booksItem == null)
            {
                return null;
            }

          
            booksItem.NumberOfItem = bookItem.NumberOfItem;
            booksItem.BookId = bookItem.BookId;
            booksItem.Barcode = bookItem.Barcode;
            booksItem.FineAmount = bookItem.FineAmount;
            booksItem.CreatedAt = DateTime.Now;

            return _bookItemRepository.Update(bookItem);
        }

        public void Delete(int id)
        {
            _bookItemRepository.Delete(id);
        }
    }
}