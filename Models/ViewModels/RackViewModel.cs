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
        public string Location {get; set;}
    }
    public class  UpdateRackViewModel : AddRackViewModel
    {
        
    }
    public class ListRackViewModel
    {
        public int RackNumber {get; set;}
        public string Location {get; set;}

    }
}