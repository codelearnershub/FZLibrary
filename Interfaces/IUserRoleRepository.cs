using System.Security.AccessControl;
using LibaryManagementSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRoleRepository
    {
        public UserRole Add(UserRole userRole);

        public UserRole FindById(int userRoleId);
        public string FindRole(int userId);
        public UserRole FindUserRole(int userId);

        public UserRole Update(UserRole userRole);

        public void Delete(int userRoleId);
    }
}