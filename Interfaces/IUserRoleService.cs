using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRoleService
    {
        public UserRole Add(int userId, int roleId);

        public UserRole FindById(int id);

        public string FindRole(int userId);
        public UserRole FindUserRole(int userId);

        public void Delete(int id);
    }
}