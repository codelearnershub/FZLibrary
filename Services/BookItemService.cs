using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class BookItemService : IBookItemService
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
                Barcode = bookItem.Barcode,
                NumberOfItem = bookItem.NumberOfItem,
                
            };

            return _bookItemRepository.Add(bookItem);
        }

        public BookItem FindById(int id)
        {
            return _bookItemRepository.FindById(id);
        }

        public BookItem Update(BookItem bookItem)
        {
            var booksItem = _bookItemRepository.FindById(bookItem.Id);
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
        //  public List<BookItem> GetAll()
        // {
        //     return _bookItemRepository.GetAll();
        // }


        public void Delete(int id)
        {
            _bookItemRepository.Delete(id);
        }

        public List<BookItem> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}