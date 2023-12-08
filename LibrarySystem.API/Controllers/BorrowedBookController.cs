using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService borrowedBookService;
        public BorrowedBookController(IBorrowedBookService borrowedBookService)
        {
            this.borrowedBookService = borrowedBookService;
        }
        [HttpGet]
        [Route("GetAllBorrowedBooks")]
        public List<Borrowedbook> GetAllBorrowedBooks()
        {
            return borrowedBookService.GetAllBorrowedBooks();
        }
        [HttpGet]
        [Route("GetBorrowedBookById/{id}")]
        public Borrowedbook GetBorrowedBookById(int id)
        {
            return borrowedBookService.GetBorrowedBookById(id);
        }
        [HttpPost]
        [Route("CreateBorrowedBook")]
        public void CreateBorrowedBook(Borrowedbook borrowedBook)
        {
            borrowedBookService.CreateBorrowedBook(borrowedBook);
        }
        [HttpDelete]
        [Route("DeleteBorrowedBook/{id}")]
        public void DeleteBorrowedBook(int id)
        {
            borrowedBookService.DeleteBorrowedBook(id);
        }
        [HttpPut]
        [Route("UpdateBorrowedBook")]
        public void UpdateBorrowedBook(Borrowedbook borrowedBook)
        {
            borrowedBookService.UpdateBorrowedBook(borrowedBook);
        }

    }
}
