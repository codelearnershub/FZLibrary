using System;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class FineViewModel
    {
        
    }
     public class AddFineViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is Required!")]
        public double FineAmount { get; set; }
        public int BookItemId {get; set;}
        public int UserId {get; set;}

    }

    public class UpdateFineViewModel : AddFineViewModel
    {
       
    }

    public class ListFineViewModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        
        public int UserId { get; set; }

        public int BookItemId { get; set; }
    }
}