using System;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class RackViewModel
    {
        
    }
    public class AddRackViewModel
    {
        [Required]
        [Display(Name="Rack Number:")]
        public int RackNumber {get; set;}
        [Required]
        [Display(Name="Rack Location:")]
        public int Location {get; set;}
    }
    public class  UpdateRackViewModel : AddRackViewModel
    {
        
    }
}