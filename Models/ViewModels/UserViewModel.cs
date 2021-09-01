using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class UserViewModel
    {
    }

    public class LoginViewModel
    {

        [Required(ErrorMessage = "Enter your Email!!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid E-Mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password!!")]
        [MinLength(4, ErrorMessage = "Password must be a minimum of 4 Characters")]
        [MaxLength(15, ErrorMessage = "Password must not be more than 15 Characters")]
        public string Password { get; set; }


    }

    public class RegisterUserViewModel : LoginViewModel
    {
        public int Id {get; set;}
      
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Confirm Password!!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Enter Phone Number!!")]
        [MaxLength(11, ErrorMessage = "Number Not Valid!!! Please Check The Number And Try Again")]
        [MinLength(11, ErrorMessage = "Number Not Valid!!! Please Check The Number And Try Again")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Address!!")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Choose Role!")]
        public int RoleId { get; set; }


        [Required(ErrorMessage = "Choose Role!")]
        public IEnumerable<SelectListItem> RoleList { get; set; }

    }
     public class ListUserViewModel
    {
        public int UserId { get; set; }
        
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber{ get; set; }

        public string RoleName { get; set; }

       

       
    }

    public class UpdateUserViewModel : RegisterUserViewModel
    {
    
    }
}
