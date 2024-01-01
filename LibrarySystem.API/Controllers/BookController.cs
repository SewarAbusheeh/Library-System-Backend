using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [Route("CreateBook")]
        [HttpPost]
        public void CreateBook(Book book)
        {
            bookService.CreateBook(book);
        }

        [Route("DeleteBook")]
        [HttpDelete]
        public void DeleteBook(int id)
        {
            bookService.DeleteBook(id);
        }

        [Route("UpdateBook")]
        [HttpPut]
        public void UpdateBook(int id,Book book)
        {
            bookService.UpdateBook(id, book);
        }

        [Route("GetAllBooks")]
        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        [Route("GetBookById")]
        [HttpGet]
        public Book GetBookById(int id)
        {
            return bookService.GetBookById(id);
        }
    }
}
