using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class RoleService
    {
         private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        public RoleService(IRoleRepository roleRepository, IUserService userService)
        {
            _roleRepository = roleRepository;
            _userService = userService;
        }

        public Role Add(int userId, string name)
        {
            var role = new Role
            {
                CreatedBy = _userService.FindById(userId).Email,
                CreatedAt = DateTime.Now,
                RoleName = name,
            };

            return _roleRepository.Add(role);
        }

        public Role FindById(int id)
        {
            return _roleRepository.FindById(id);
        }

        public Role Update(int roleId, string name)
        {
            var role = _roleRepository.FindById(roleId);
            if (role == null)
            {
                return null;
            }

            role.RoleName = name;
            role.UpdatedAt = DateTime.Now;

            return _roleRepository.Update(role);
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

    }
}