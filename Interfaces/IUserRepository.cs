using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;
namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User user);

        public User FindById(int userId);

        public User FindByEmail(string userEmail);

        public List<User> GetAllUser();
    
        public bool Exists(int id);

        public User Update(User user);

        public void Delete(int userId);
    }
}