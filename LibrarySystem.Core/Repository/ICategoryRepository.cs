using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        void UpdateCategory(int id, Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
