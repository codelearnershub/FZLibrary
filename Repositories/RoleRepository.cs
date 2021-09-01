using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryManagementSystem2.Repositories
{
    public class RoleRepository : IRoleRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public RoleRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Role Add(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
            return role;
        }

        public void Delete(int roleId)
        {
            var role = FindById(roleId);

            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
            }
        }
          public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }
         public Role FindByName(string roleName)
        {
            return _dbContext.Roles.FirstOrDefault(u => u.RoleName.Equals(roleName));
        }

        public Role FindById(int roleId)
        {
            return _dbContext.Roles.FirstOrDefault(u => u.Id.Equals(roleId));
        }

        public Role Update(Role role)
        {
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
            return role;
        }
    }
}