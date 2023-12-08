using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.Infra.Repository
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly IDbContext dbContext;

        public BorrowedBookRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Borrowedbook> GetAllBorrowedBooks()
        {
            IEnumerable<Borrowedbook> result = dbContext.Connection.Query<Borrowedbook>("BorrowedBooks_Package.GetAllBorrowedBooks", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Borrowedbook GetBorrowedBookById(int borrowId)
        {
            var p = new DynamicParameters();
            p.Add("borrowId", borrowId);
            var result = dbContext.Connection.Query<Borrowedbook>("BorrowedBooks_Package.GetBorrowedBookById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateBorrowedBook(Borrowedbook borrowedBook)
        {
            var p = new DynamicParameters();
            p.Add("userId", borrowedBook.UserId);
            p.Add("bookId", borrowedBook.BookId);
            p.Add("borrowDateFrom", borrowedBook.BorrowDateFrom);
            p.Add("borrowDateTo", borrowedBook.BorrowDateTo);
            p.Add("returnedDate", borrowedBook.ReturnedDate);
            p.Add("finePercentage", borrowedBook.FinePercentage);
            p.Add("isFinePaid", borrowedBook.IsfinePaid);

            dbContext.Connection.Execute("BorrowedBooks_Package.CreateBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBorrowedBook(Borrowedbook borrowedBook)
        {
            var p = new DynamicParameters();
            p.Add("borrowId", borrowedBook.BorrowId);
            p.Add("userId", borrowedBook.UserId);
            p.Add("bookId", borrowedBook.BookId);
            p.Add("borrowDateFrom", borrowedBook.BorrowDateFrom);
            p.Add("borrowDateTo", borrowedBook.BorrowDateTo);
            p.Add("returnedDate", borrowedBook.ReturnedDate);
            p.Add("finePercentage", borrowedBook.FinePercentage);
            p.Add("isFinePaid", borrowedBook.IsfinePaid);

            dbContext.Connection.Execute("BorrowedBooks_Package.UpdateBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBorrowedBook(int borrowId)
        {
            var p = new DynamicParameters();
            p.Add("borrowId", borrowId);

            dbContext.Connection.Execute("BorrowedBooks_Package.DeleteBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }
    }
}
