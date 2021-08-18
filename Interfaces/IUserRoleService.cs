using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRoleService
    {
        public UserRole Add(int userId, int roleId);

        public UserRole FindById(int id);

        public void Delete(int id);
    }
}