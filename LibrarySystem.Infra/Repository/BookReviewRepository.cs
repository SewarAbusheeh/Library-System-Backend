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
            p.Add("bookReviewId", id);
            var result = dbContext.Connection.Query<BookReview>("BookReview_Package.GetBookReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateBookReview(BookReview bookReview)
        {
            var p = new DynamicParameters();
            p.Add("userId", bookReview.UserId);
            p.Add("bookId", bookReview.BookId);
            p.Add("borrowId", bookReview.BorrowId);
            p.Add("rating", bookReview.Rating);
            p.Add("reviewText", bookReview.ReviewText);
            p.Add("reviewDate", bookReview.ReviewDate);

            var result = dbContext.Connection.Execute("BookReview_Package.CreateBookReview", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBookReview(BookReview bookReview)
        {
            var p = new DynamicParameters();
            p.Add("bookReviewId", bookReview.BookReviewId);
            p.Add("userId", bookReview.UserId);
            p.Add("bookId", bookReview.BookId);
            p.Add("borrowId", bookReview.BorrowId);
            p.Add("rating", bookReview.Rating);
            p.Add("reviewText", bookReview.ReviewText);
            p.Add("reviewDate", bookReview.ReviewDate);

            var result = dbContext.Connection.Execute("BookReview_Package.UpdateBookReview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBookReview(int bookReviewId)
        {
            var p = new DynamicParameters();
            p.Add("bookReviewId", bookReviewId);

            var result = dbContext.Connection.Execute("BookReview_Package.DeleteBookReview", p, commandType: CommandType.StoredProcedure);
        }
    }
}
