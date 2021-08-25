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
<<<<<<< HEAD
        public string FindRole(int userId);
        public UserRole FindUserRole(int userId);
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public UserRole Update(UserRole userRole);

        public void Delete(int userRoleId);
    }
}