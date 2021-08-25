using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserRoleService
    {
        public UserRole Add(int userId, int roleId);

        public UserRole FindById(int id);

<<<<<<< HEAD
        public string FindRole(int userId);
        public UserRole FindUserRole(int userId);

=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
        public void Delete(int id);
    }
}