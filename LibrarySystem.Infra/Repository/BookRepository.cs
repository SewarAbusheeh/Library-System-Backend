using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContext dbContext;

        public BookRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateBook(Book book)
        {
            var p = new DynamicParameters();
            p.Add("p_title", book.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_author", book.Author, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_description", book.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_bookImgPath", book.Book_Img_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_bookPdfPath", book.Book_Pdf_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_publicationDate", book.Publication_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_pricePerDay", book.Price_Per_Day, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_avgRating", book.Avg_Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_categoryId", book.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("BOOKS_PACKAGE.CreateBook", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBook(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_bookId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("BOOKS_PACKAGE.DeleteBook", p, commandType: CommandType.StoredProcedure);
        }

        public List<Book> GetAllBooks()
        {
            IEnumerable<Book> result = dbContext.Connection.Query<Book>("BOOKS_PACKAGE.GetAllBooks", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Book GetBookById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_bookId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Book>("BOOKS_PACKAGE.GetBookById",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public void UpdateBook(int id, Book book)
        {
            var p = new DynamicParameters();
            p.Add("p_bookId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", book.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_author", book.Author, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_description", book.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_bookImgPath", book.Book_Img_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_bookPdfPath", book.Book_Pdf_Path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_publicationDate", book.Publication_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_pricePerDay", book.Price_Per_Day, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_avgRating", book.Avg_Rating, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_categoryId", book.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("BOOKS_PACKAGE.UpdateBook", p, commandType: CommandType.StoredProcedure);

        }
    }
}
