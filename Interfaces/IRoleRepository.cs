using System.IO.Enumeration;
using System.IO;
using System.Security.AccessControl;
using System;
using System.Linq;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IRoleRepository
    {
         public Role Add(Role role);

        public Role FindById(int roleId);

        public Role Update(Role role);
        public Role FindByName(string roleName);

        public List<Role> GetAllRoles();

        public void Delete(int roleId);
    }
}