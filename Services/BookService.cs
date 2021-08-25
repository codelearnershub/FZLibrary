
using System.Collections.Generic;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class BookService : IBookService
    {
            private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Book AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public Book UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }

        
    }
}
