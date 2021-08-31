using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IBookItemService
    {
        public List<BookItem> GetAll();

        public BookItem FindById(int id);

        public BookItem Add(BookItem bookItem);

        public BookItem Update(BookItem bookItem);

        public void Delete(int id);
    }
}