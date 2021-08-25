using System.Collections.Generic;
using System.Linq;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
         private readonly LibaryManagementDBContext _dbContext;

        public CategoryRepository(LibaryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category AddCategory(Category category)
        {
             _dbContext.Categories.Add(category);
             _dbContext.SaveChanges();
             return category;
        }

        public Category FindById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public Category UpdateCategory(Category category)
        {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return category; 
        }

        public void Delete(int id)
        {
            var category = FindById(id);
            
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Category Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}






