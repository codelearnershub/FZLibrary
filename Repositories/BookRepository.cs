using System.Linq;
using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;


namespace LibaryManagementSystem2.Repositories
{
    public class BookRepository : IBookRepository
    {
           private readonly LibaryManagementDBContext _dbContext;
        public BookRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public void DeleteBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _dbContext.Books.Any(b => b.BookId == id);
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public Book UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return book;
        }

        
    }
}






