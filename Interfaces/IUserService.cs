using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(int userId, string password, string lastName, string firstName, string email, string phoneNumber, string address, int roleId);
      
        public User LoginUser(string email, string password);

        public User FindById(int Id);
        

        public User Update(int id, string password, string lastName, string firstName, string email, string phoneNumber, string address);


        public void Delete(int id);
        
    }
}