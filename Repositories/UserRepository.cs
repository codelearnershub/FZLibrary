using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

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
<<<<<<< HEAD
         public bool Exists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }
         public Role FindRole(string name)
        {
            return  _dbContext.Roles.FirstOrDefault(r => r.RoleName.Equals(name));
        }

=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

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
<<<<<<< HEAD
          public List<User> GetAllUser()
        {
            return _dbContext.Users.ToList();
        }
          public UserRole FindUserRole(int userId)
        {
            return _dbContext.UserRoles.Include(r => r.Role).FirstOrDefault(u => u.UserId == userId);

        }
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}