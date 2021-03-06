using System;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class UserRoleService : IUserRoleService
    {
         private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public UserRole Add(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                CreatedAt = DateTime.Now,
                UserId = userId,
                RoleId = roleId,
            };

            return _userRoleRepository.Add(userRole);
        }

        public UserRole FindById(int id)
        {
            return _userRoleRepository.FindById(id);
        }

        public string FindRole(int userId)
        {
           return _userRoleRepository.FindRole(userId);
           
        }
        
        public UserRole FindUserRole(int userId)
        {
            return _userRoleRepository.FindUserRole(userId);

        }


        public void Delete(int id)
        {
            _userRoleRepository.Delete(id);
        }

    }
}