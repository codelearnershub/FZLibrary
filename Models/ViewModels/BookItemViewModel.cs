using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class BookItemViewModel
    {
    }
    public class AddBookItemViewModel
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Input Number of Books!")]
        public int NumberOfItem { get; set; }
        public Guid Barcode {get; set;}
        public DateTime CreatedAt {get; set;}
        


        [Required(ErrorMessage = "Select Book!")]
        public IEnumerable<SelectListItem> Book { get; set; }


        [Required(ErrorMessage = "Select Book!")]
        public int BookId { get; set; }

    }
    public class UpdateBookItemViewModel : AddBookItemViewModel
    {
        
    }
    public class ListBookItemViewModel 
    {
        public int Id {get; set;}

     
        public Guid Barcode { get; set;}
        public DateTime CreatedAt {get; set;}
          public IEnumerable<SelectListItem> BookList { get; set; }

        

    }

}