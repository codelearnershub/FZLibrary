using System;
namespace LibaryManagementSystem2.Models
{
    public class UserRole : BaseEntity
    {
        public User user {get; set;}
        public int UserId {get; set;}
<<<<<<< HEAD
        public Role Role {get; set;}
=======
        public Role role {get; set;}
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
        public int RoleId {get; set;}
       
    }
    
}