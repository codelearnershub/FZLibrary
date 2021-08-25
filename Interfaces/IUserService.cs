<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserService
    {
<<<<<<< HEAD
        public void RegisterUser(User user);
      
        public User LoginUser(User user);
=======
        public void RegisterUser(int userId, string password, string lastName, string firstName, string email, string phoneNumber, string address, int roleId);
      
        public User LoginUser(string email, string password);
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public User FindById(int Id);
        

<<<<<<< HEAD
        public User Update(User user);
        public IEnumerable<User> GetAllUser();
=======
        public User Update(int id, string password, string lastName, string firstName, string email, string phoneNumber, string address);
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea


        public void Delete(int id);
        
    }
}