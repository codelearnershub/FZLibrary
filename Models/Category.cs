using System;
using System.Collections.Generic;

namespace LibaryManagementSystem2.Models
{
    public class Category : BaseEntity
    {
        public string Name {get; set;}
        public List<Book> Books {get; set;}
    }
}