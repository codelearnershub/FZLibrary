using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
<<<<<<< HEAD
    public class RoleService : IRoleService
=======
    public class RoleService
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
    {
         private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        public RoleService(IRoleRepository roleRepository, IUserService userService)
        {
            _roleRepository = roleRepository;
            _userService = userService;
        }

<<<<<<< HEAD
        public Role Add(Role role)
        {
            var roles = new Role
            {
               
                CreatedAt = DateTime.Now,
                RoleName = role.RoleName,
=======
        public Role Add(int userId, string name)
        {
            var role = new Role
            {
                CreatedBy = _userService.FindById(userId).Email,
                CreatedAt = DateTime.Now,
                RoleName = name,
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
            };

            return _roleRepository.Add(role);
        }

        public Role FindById(int id)
        {
            return _roleRepository.FindById(id);
        }

<<<<<<< HEAD
        public Role Update(Role role)
        {
            var roles = _roleRepository.FindById(role.Id);
=======
        public Role Update(int roleId, string name)
        {
            var role = _roleRepository.FindById(roleId);
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
            if (role == null)
            {
                return null;
            }

<<<<<<< HEAD
            role.RoleName = role.RoleName;
          

            return _roleRepository.Update(role);
        }
          public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
=======
            role.RoleName = name;
            role.UpdatedAt = DateTime.Now;

            return _roleRepository.Update(role);
        }
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

<<<<<<< HEAD
         public Role FindByName(string roleName)
        {
          return  _roleRepository.FindByName(roleName);
        }
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
    }
}