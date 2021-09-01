using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IRoleService
    {
        public Role Add(Role role);

        public Role FindById(int id);

        public Role Update(Role role);
        public Role FindByName(string roleName);

        public IEnumerable<Role> GetAllRoles();

        public void Delete(int id);
    }
}