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

namespace LibrarySystem.Infra.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IDbContext dbContext;

        public LibraryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateLibrary(Library library)
        {
            var p = new DynamicParameters();
            p.Add("p_name", library.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_locationLatitude", library.Location_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_locationLongitude", library.Location_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_phoneNumber", library.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", library.Image_Path1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", library.Image_Path2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_description", library.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", library.Email, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("LIBRARIES_PACKAGE.CreateLibrary", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLibrary(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_libraryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("LIBRARIES_PACKAGE.DeleteLibrary", p, commandType: CommandType.StoredProcedure);

        }

        public List<Library> GetAllLibraries()
        {
            IEnumerable<Library> result = dbContext.Connection.Query<Library>("LIBRARIES_PACKAGE.GetAllLibraries", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Library GetLibraryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_libraryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Library>("LIBRARIES_PACKAGE.GetLibraryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateLibrary(int id, Library library)
        {
            var p = new DynamicParameters();
            p.Add("p_libraryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_name", library.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_locationLatitude", library.Location_Latitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_locationLongitude", library.Location_Longitude, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_phoneNumber", library.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", library.Image_Path1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", library.Image_Path2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_description", library.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", library.Email, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("LIBRARIES_PACKAGE.UpdateLibrary", p, commandType: CommandType.StoredProcedure);
        }

        public List<BorrowedBooks_LibraryDTO> GetBorrowedBooksCountInLibraries()
        {
            var result = dbContext.Connection.Query<BorrowedBooks_LibraryDTO>("LIBRARIES_PACKAGE.GetBorrowedBooksCountInLibraries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
