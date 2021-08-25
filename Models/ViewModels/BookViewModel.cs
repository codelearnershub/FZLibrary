using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class BookViewModel
    {
       
    }
    public class AddBookViewModel
    {
        public int Id {get; set;}
        [Required(ErrorMessage="Book name is required")]
        [Display(Name="Book Name:")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Rack Number:")]
        public int RackNumber {get; set;}
        [Required]
        [Display(Name="Maximum Days For Borrow:")]
          
        public int MaxIssueDays {get; set;}
          [Required(ErrorMessage = "Choose Category!")]
        public IEnumerable<sssssss> CategoryList { get; set; }
        public int NumberOfItem {get; set;}
        public int CategoryId {get; set;}
        public int BookItemId {get; set;}
    }
    public class ListBookViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfItem {get; set;}
        public int RackNumber {get; set;}
      
        public int CategoryId {get; set;}

        public int MaxIssueDays { get; set; }
    }

    public class UpdateBookViewModel : AddBookViewModel
    {

    }
}