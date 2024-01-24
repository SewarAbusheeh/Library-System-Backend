using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewService bookReviewService;
        public BookReviewController(IBookReviewService bookReviewService)
        {
            this.bookReviewService = bookReviewService;
        }
        [HttpGet]
        [Route("GetAllBookReviews")]
        public List<BookReview> GetAllBookReviews()
        {
            return bookReviewService.GetAllBookReviews();
        }
        [HttpGet]
        [Route("GetBookReviewById/{id}")]
        public BookReview GetBookReviewById(int id)
        {
            return bookReviewService.GetBookReviewById(id);
        }

        [HttpPost]
        [Route("CreateBookReview")]
        public void CreateBookReview(BookReview bookReview)
        {
            bookReviewService.CreateBookReview(bookReview);
        }
        [HttpDelete]
        [Route("DeleteBookReview/{id}")]
        public void DeleteBookReview(int id)
        {
            bookReviewService.DeleteBookReview(id);
        }
        [HttpPut]
        [Route("UpdateBookReview")]
        public void UpdateBookReview(BookReview bookReview)
        {
            bookReviewService.UpdateBookReview(bookReview);
        }

        [HttpGet]
        [Route("GetBookNameAndReview")]
        public List<BookReviewWithBookInfo> GetBookNameAndReview()
        {
            return bookReviewService.GetBookNameAndReview();
        }
    }
}
