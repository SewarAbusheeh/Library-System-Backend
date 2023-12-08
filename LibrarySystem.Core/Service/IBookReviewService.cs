using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IBookReviewService
    {
        List<BookReview> GetAllBookReviews();
        void CreateBookReview(BookReview bookReview);
        void DeleteBookReview(int id);
        public void UpdateBookReview(BookReview bookReview);
        BookReview GetBookReviewById(int id);
    }
}
