using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
using LibaryManagementSystem2.Models;
namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User user);

        public User FindById(int userId);

        public User FindByEmail(string userEmail);

<<<<<<< HEAD
        public List<User> GetAllUser();
    
        public bool Exists(int id);

=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
        public User Update(User user);

        public void Delete(int userId);
    }
}