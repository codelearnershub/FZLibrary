using System;
using System.Collections.Generic;

namespace LibaryManagementSystem2.Models
{
    public class Role : BaseEntity
    { 
        
        public string RoleName {get; set;}
        public List<UserRole> UserRoles { get; set; }
    }
}