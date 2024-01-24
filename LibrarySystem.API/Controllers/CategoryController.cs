using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Route("CreateCategory")]
        [HttpPost]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void CreateCategory(Category category)
        {
            categoryService.CreateCategory(category);
        }

        [Route("UpdateCategory")]
        [HttpPut]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateCategory(int id, Category category)
        {
            categoryService.UpdateCategory(id, category);
        }

        [Route("DeleteCategory")]
        [HttpDelete]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id);
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return categoryService.GetAllCategories();
        }

        [Route("GetCategoryById")]
        [HttpGet]
        public Category GetCategoryById(int id)
        {
            return categoryService.GetCategoryById(id);
        }
        [Route("GetCategoriesByLibraryId")]
        [HttpGet]
        public List<Category> GetCategoriesByLibraryId(int id)
        {
            return categoryService.GetCategoriesByLibraryId(id);
        }
        [Route("GetBooksByCategoryId")]
        [HttpGet]
        public List<Book> GetBooksByCategoryId(int id)
        {
            return categoryService.GetBooksByCategoryId(id);
        }
    }
}
