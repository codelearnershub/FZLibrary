using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Models.ViewModels
{
    public class RoleViewModel
    {
        
    }

    public class AddRoleViewModel
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Enter Role!!")]
        public string Name { get; set; }
    }
     public class ListRoleViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
    }


    public class UpdateRoleViewModel : AddRoleViewModel
    {

    }
}
 
