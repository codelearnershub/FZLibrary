using System;
using System.Collections.Generic;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class RoleService : IRoleService
    {
         private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        public RoleService(IRoleRepository roleRepository, IUserService userService)
        {
            _roleRepository = roleRepository;
            _userService = userService;
        }

        public Role Add(Role role)
        {
            var roles = new Role
            {
               
                CreatedAt = DateTime.Now,
                RoleName = role.RoleName,
            };

            return _roleRepository.Add(role);
        }

        public Role FindById(int id)
        {
            return _roleRepository.FindById(id);
        }

        public Role Update(Role role)
        {
            var roles = _roleRepository.FindById(role.Id);
            if (role == null)
            {
                return null;
            }

            role.RoleName = role.RoleName;
          

            return _roleRepository.Update(role);
        }
          public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

         public Role FindByName(string roleName)
        {
          return  _roleRepository.FindByName(roleName);
        }
    }
}