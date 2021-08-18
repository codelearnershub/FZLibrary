using System;
using LibaryManagementSystem2.Models;
namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User user);

        public User FindById(int userId);

        public User FindByEmail(string userEmail);

        public User Update(User user);

        public void Delete(int userId);
    }
}