using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IBookService
    {
        void CreateBook(Book book);
        void UpdateBook(int id, Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        List<Book> GetAllBooks();

        public List<Book> topBooks();
        public Task<List<Category>> GetAllCategoryBooks();
        public Book FindBestSellingBook();
    }
}
