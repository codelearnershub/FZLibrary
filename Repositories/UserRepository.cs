using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Repositories
{
    public class UserRepository : IUserRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public UserRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void Delete(int userId)
        {
            var user = FindById(userId);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User FindById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id.Equals(userId));
        }

        public User FindByEmail(string userEmail)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email.Equals(userEmail));
        }

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}