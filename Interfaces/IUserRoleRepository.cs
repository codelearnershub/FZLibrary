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

        public UserRole Update(UserRole userRole);

        public void Delete(int userRoleId);
    }
}