using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibaryManagementSystem2.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
       private readonly LibaryManagementDBContext _dbContext;

        public UserRoleRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRole Add(UserRole userRole)
        {
            _dbContext.UserRoles.Add(userRole);
            _dbContext.SaveChanges();
            return userRole;
        }

        public void Delete(int userRoleId)
        {
            var userRole = FindById(userRoleId);

            if (userRole != null)
            {
                _dbContext.UserRoles.Remove(userRole);
                _dbContext.SaveChanges();
            }
        }

        public UserRole FindById(int userRoleId)
        {
            return _dbContext.UserRoles.FirstOrDefault(u => u.Id.Equals(userRoleId));
        }

      
        public string FindRole(int userId)
        {
            return  _dbContext.UserRoles.Include(r=> r.Role).FirstOrDefault(u => u.UserId == userId).Role.RoleName;
           
        }

        public UserRole FindUserRole(int userId)
        {
            return _dbContext.UserRoles.Include(r => r.Role).FirstOrDefault(u => u.UserId == userId);

        }


        public UserRole Update(UserRole userRole)
        {
            _dbContext.UserRoles.Update(userRole);
            _dbContext.SaveChanges();
            return userRole;
        } 
    }
}