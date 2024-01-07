using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class BookReviewService:IBookReviewService
    {
        private readonly IBookReviewRepository bookReviewRepository;
        public BookReviewService(IBookReviewRepository bookReviewRepository) 
        {
            this.bookReviewRepository = bookReviewRepository;
        }
        public List<BookReview> GetAllBookReviews()
        {
            return bookReviewRepository.GetAllBookReviews();
        }
        public void CreateBookReview(BookReview bookReview)
        {
            bookReviewRepository.CreateBookReview(bookReview);
        }
        public void DeleteBookReview(int id)
        {
            bookReviewRepository.DeleteBookReview(id);
        }
        public void UpdateBookReview(BookReview bookReview)
        {
            bookReviewRepository.UpdateBookReview(bookReview);
        }
        public BookReview GetBookReviewById(int id)
        {
            return bookReviewRepository.GetBookReviewById(id);
        }
    

    }
}
