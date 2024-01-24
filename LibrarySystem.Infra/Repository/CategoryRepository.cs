using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibrarySystem.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryName", category.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_libraryId", category.Library_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("CATEGORY_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CATEGORY_PACKAGE.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GetCategoryById",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateCategory(int id, Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_categoryName", category.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_libraryId", category.Library_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("CATEGORY_PACKAGE.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Category> GetCategoryByLibraryId(int id)
        {
            var p = new DynamicParameters();
            p.Add("LIBRARY_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // Call the stored procedure and retrieve the results
            var result = dbContext.Connection.Query<Category>("GetCategoryByLibraryId", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public List<Category> GetCategoriesByLibraryId(int id)
        {
            var p = new DynamicParameters();
            p.Add("libraryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // Call the stored procedure and retrieve the results
            var result = dbContext.Connection.Query<Category>("GetCategoryByLibraryId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Book> GetBooksByCategoryId(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_CategoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // Call the stored procedure and retrieve the results
            var result = dbContext.Connection.Query<Book>("GetBooksByCategory1", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //public async Task<Category> GetAllCategoryLibraries()
        //{
        //    var parameters = new DynamicParameters();
        //    var result = await dbContext.Connection.QueryAsync<Category, Library, Category>(
        //        "GetAllCategoryLibraries",
        //        (category, library) =>
        //        {
        //            category.Library = library;
        //            return category;
        //        },
        //        splitOn: "Library_Id",
        //        param: null,
        //        commandType: CommandType.StoredProcedure
        //    );

        //    return result.FirstOrDefault();
        //}
        public List<CategoryLibrary> GetAllCategoryLibraries()
        {

            var result = dbContext.Connection.Query<CategoryLibrary>("GetAllCategoryLibraries", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }

}
