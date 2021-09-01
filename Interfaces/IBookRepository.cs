using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IBookRepository
    {
      public List<Book> GetAll();  

        public Book GetBook(int id);

        public Book AddBook(Book book);

        public Book UpdateBook(Book book);

        public void DeleteBook(int id);

        public bool Exists(int id);
    }
}



