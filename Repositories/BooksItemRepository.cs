
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Repositories
{
    public class BooksItemRepository : IBookItemRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public BooksItemRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookItem Add(BookItem bookItem)
        {
            _dbContext.BookItems.Add(bookItem);
            _dbContext.SaveChanges();
            return bookItem;
        }

        public void Delete(int bookItemId)
        {
            var bookItem = FindById(bookItemId);

            if (bookItem != null)
            {
                _dbContext.BookItems.Remove(bookItem);
                _dbContext.SaveChanges();
            }
        }
         public List<BookItem> GetAll()
        {
            return _dbContext.BookItems.ToList();
        }

        public BookItem FindById(int bookItemId)
        {
            return _dbContext.BookItems.FirstOrDefault(u => u.Id.Equals(bookItemId));
        }

        public BookItem Update(BookItem bookItem)
        {
            _dbContext.BookItems.Update(bookItem);
            _dbContext.SaveChanges();
            return bookItem;
        }
    }
}