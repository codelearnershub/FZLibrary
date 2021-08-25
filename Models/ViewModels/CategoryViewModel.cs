using System;
using System.ComponentModel.DataAnnotations;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class CategoryViewModel
    {
        
    }
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name="Category Name:")]
        public string Name {get; set;}
    }
    public class UpdateCategoryViewModel : AddCategoryViewModel
    {
        
    }
}