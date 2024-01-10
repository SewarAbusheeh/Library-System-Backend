using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(int id, Category category)
        {
            categoryRepository.UpdateCategory(id, category);
        }
        public List<Category> GetCategoriesByLibraryId(int id)
        {
           return  categoryRepository.GetCategoriesByLibraryId(id);
        }
        public List<Book> GetBooksByCategoryId(int id)
        {
            return categoryRepository.GetBooksByCategoryId(id);
        }
       
    }
}
