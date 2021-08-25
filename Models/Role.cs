using System;
using System.Collections.Generic;

namespace LibaryManagementSystem2.Models
{
    public class Role : BaseEntity
    { 
        
        public string RoleName {get; set;}
<<<<<<< HEAD
        public int UserId {get; set;}
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
        public List<UserRole> UserRoles { get; set; }
    }
}