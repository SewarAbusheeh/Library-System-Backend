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
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void CreateBook(Book book)
        {
            bookRepository.CreateBook(book);
        }

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public void UpdateBook(int id, Book book)
        {
            bookRepository.UpdateBook(id, book);
        }
    }
}
