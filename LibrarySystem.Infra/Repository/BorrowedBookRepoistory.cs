using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibrarySystem.Infra.Repository
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly IDbContext dbContext;
        private  readonly IBookService bookService;

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
            p.Add("p_borrowId", borrowId);
            var result = dbContext.Connection.Query<Borrowedbook>("BorrowedBooks_Package.GetBorrowedBookById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateBorrowedBook(Borrowedbook borrowedBook)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", borrowedBook.User_Id);
            p.Add("p_bookId", borrowedBook.Book_Id);
            p.Add("p_borrowDateFrom", borrowedBook.Borrow_Date_From);
            p.Add("p_borrowDateTo", borrowedBook.Borrow_Date_To);
            p.Add("p_returnedDate", borrowedBook.Returned_Date);
            p.Add("p_finePercentage", borrowedBook.Fine_Percentage);
            p.Add("p_isFinePaid", borrowedBook.Isfine_Paid);

            dbContext.Connection.Execute("BorrowedBooks_Package.CreateBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBorrowedBook(Borrowedbook borrowedBook)
        {
            var p = new DynamicParameters();
            p.Add("p_borrowId", borrowedBook.Borrow_Id);
            p.Add("p_userId", borrowedBook.User_Id);
            p.Add("p_bookId", borrowedBook.Book_Id);
            p.Add("p_borrowDateFrom", borrowedBook.Borrow_Date_From);
            p.Add("p_borrowDateTo", borrowedBook.Borrow_Date_To);
            p.Add("p_returnedDate", borrowedBook.Returned_Date);
            p.Add("p_finePercentage", borrowedBook.Fine_Percentage);
            p.Add("p_isFinePaid", borrowedBook.Isfine_Paid);

            dbContext.Connection.Execute("BorrowedBooks_Package.UpdateBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBorrowedBook(int borrowId)
        {
            var p = new DynamicParameters();
            p.Add("p_borrowId", borrowId);

            dbContext.Connection.Execute("BorrowedBooks_Package.DeleteBorrowedBook", p, commandType: CommandType.StoredProcedure);
        }
        public  List<BorrowedBooksDetails> GetBorrowedBooksDetails()
        {
           
            IEnumerable<BorrowedBooksDetails> result = dbContext.Connection.Query<BorrowedBooksDetails>("GetBorrowedBooksDetails1", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<GetBorrowedBooksDetailsByUserIdDTO> BorrowedbooksByIdUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetBorrowedBooksDetailsByUserIdDTO> result = dbContext.Connection.Query<GetBorrowedBooksDetailsByUserIdDTO>("GetBorrowedBooksDetailsByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
