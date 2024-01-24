using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public interface IBookReviewRepository
    {
        List<BookReview> GetAllBookReviews();
        void CreateBookReview(BookReview bookReview);
        void DeleteBookReview(int id);
        public void UpdateBookReview(BookReview bookReview);
        BookReview GetBookReviewById(int id);
        public List<BookReviewWithBookInfo> GetBookNameAndReview();
    }
}
