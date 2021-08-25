using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IBookItemRepository
    {
        public BookItem Add(BookItem bookItem);

        public BookItem FindById(int bookItemId);
         public List<BookItem> GetAll();


        public BookItem Update(BookItem bookItem);

        public void Delete(int bookItemId);
    }
}