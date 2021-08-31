using System.Collections.Generic;
using LibaryManagementSystem.Interfaces;
using LibaryManagementSystem2.Models;

namespace LibaryManagementSystem2.Services
{
    public class CategoryService : ICategoryService
    {
         private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category FindById(int id)
        {
            return categoryRepository.FindById(id);
        }

        public Category Create(Category category)
        {
            return categoryRepository.Create(category);
        }

        public Category Update(Category category)
        {
            return categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public bool Exists(int id)
        {
            return categoryRepository.Exists(id);
        }
    }
}

