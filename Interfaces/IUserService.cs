using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(User user);
      
         public User LoginUser(User user);
       
        // public User LoginUser(string email, string password);

        public User FindById(int Id);
       
        

        public IEnumerable<User> GetAllUser();
        public User Update(User user);


        public void Delete(int id);
        
    }
}