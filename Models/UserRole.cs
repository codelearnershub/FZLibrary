using System;
namespace LibaryManagementSystem2.Models
{
    public class UserRole : BaseEntity
    {
        public User user {get; set;}
        public int UserId {get; set;}
        public Role role {get; set;}
        public int RoleId {get; set;}
       
    }
    
}