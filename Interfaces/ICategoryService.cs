using System.Collections.Generic;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Interfaces
{    
    public interface ICategoryService
    {
       public Category FindById(int id);

        public Category Create(Category category);

        public Category Update(Category category);

        public void Delete(int id);

        public List<Category> GetAll();

        public bool Exists(int id);
    }
}