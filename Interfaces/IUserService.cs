using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(User user);
      
        public User LoginUser(User user);

        public User FindById(int Id);
        

        public User Update(User user);
        public IEnumerable<User> GetAllUser();


        public void Delete(int id);
        
    }
}