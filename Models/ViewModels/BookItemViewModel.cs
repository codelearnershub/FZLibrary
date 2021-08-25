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
        [Required(ErrorMessage = "Input Number of Books!")]
        public int NumberOfItem { get; set; }


        [Required(ErrorMessage = "Select Book!")]
        public IEnumerable<SelectListItem> Book { get; set; }


        [Required(ErrorMessage = "Select Book!")]
        public int BookId { get; set; }

    }

}