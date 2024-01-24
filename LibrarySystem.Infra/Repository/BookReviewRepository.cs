using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace LibrarySystem.Infra.Repository
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly IDbContext dbContext;

        public BookReviewRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BookReview> GetAllBookReviews()
        {
            IEnumerable<BookReview> result = dbContext.Connection.Query<BookReview>("BookReview_Package.GetAllBookReviews", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public BookReview GetBookReviewById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", id);
            var result = dbContext.Connection.Query<BookReview>("BookReview_Package.GetBookReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateBookReview(BookReview bookReview)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", bookReview.User_Id);
            p.Add("p_bookId", bookReview.Book_Id);
            p.Add("p_borrowId", bookReview.Borrow_Id);
            p.Add("p_rating", bookReview.Rating);
            p.Add("p_reviewText", bookReview.Review_Text);
            p.Add("p_reviewDate", bookReview.Review_Date);

            var result = dbContext.Connection.Execute("BookReview_Package.CreateBookReview", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBookReview(BookReview bookReview)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", bookReview.Book_Review_Id);
            p.Add("p_userId", bookReview.User_Id);
            p.Add("p_bookId", bookReview.Book_Id);
            p.Add("p_borrowId", bookReview.Borrow_Id);
            p.Add("p_rating", bookReview.Rating);
            p.Add("p_reviewText", bookReview.Review_Text);
            p.Add("p_reviewDate", bookReview.Review_Date);

            var result = dbContext.Connection.Execute("BookReview_Package.UpdateBookReview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBookReview(int bookReviewId)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", bookReviewId);

            var result = dbContext.Connection.Execute("BookReview_Package.DeleteBookReview", p, commandType: CommandType.StoredProcedure);
        }

        public List<BookReviewWithBookInfo> GetBookNameAndReview()
        {

var  result = dbContext.Connection.Query<BookReviewWithBookInfo>("GetBookNameAndReview", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
