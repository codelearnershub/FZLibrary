using System;
namespace LibaryManagementSystem2.Models
{
    public class BooksCategory
    {
       public int BookId {get; set;}
       public Book Book {get; set;}

       public int CategoryId {get; set;}
       public Category Category {get; set;}
        

    }
}