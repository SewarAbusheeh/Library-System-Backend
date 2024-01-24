using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [RequiresClaim("roleid", "1")] 
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
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteBorrowedBook(int id)
        {
            borrowedBookService.DeleteBorrowedBook(id);
        }
        [HttpPut]
        [Route("UpdateBorrowedBook")]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateBorrowedBook(Borrowedbook borrowedBook) 
        {
            borrowedBookService.UpdateBorrowedBook(borrowedBook);
        }
        [HttpGet]
        [Route("GetBorrowedBooksDetails")]
        public List<BorrowedBooksDetails> GetBorrowedBooksDetails()
        {
            return borrowedBookService.GetBorrowedBooksDetails();
        }
        [HttpGet]
        [Route("BorrowedbooksByIdUser")]
        public List<GetBorrowedBooksDetailsByUserIdDTO> BorrowedbooksByIdUser(int id )
        {
            return borrowedBookService.BorrowedbooksByIdUser(id);
        }

        [HttpGet]
        [Route("GetBorrowedBooksDetailsByUserIdAndBookID")]
        public GetBorrowedBooksDetailsByUserIdDTO GetBorrowedBooksDetailsByUserIdAndBookID(int userID, int bookID)
        {
            return borrowedBookService.GetBorrowedBooksDetailsByUserIdAndBookID(userID, bookID);
        }

    }
}
