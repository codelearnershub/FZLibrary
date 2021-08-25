using System;
namespace LibaryManagementSystem2.Models
{
    public class User : BaseEntity
    {
        
       
       public string FirstName{get; set;}

        public string LastName{get; set;}

        public string Email{get; set;}

        public string Password{get; set;}
        public string PasswordHash { get; set; }

        public string HashSalt { get; set; }
         public string PhoneNumber { get; set; }
<<<<<<< HEAD
         public int RoleId {get; set;}
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public string Address { get; set; }
    }
}