using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class BorrowedBookService: IBorrowedBookService
    {
        private readonly IBorrowedBookRepository borrowedBookRepository;
        public BorrowedBookService(IBorrowedBookRepository borrowedBookRepository)
        {
            this.borrowedBookRepository = borrowedBookRepository;
        }
        public List<Borrowedbook> GetAllBorrowedBooks()
        {
            return borrowedBookRepository.GetAllBorrowedBooks();
        }
        public void CreateBorrowedBook(Borrowedbook borrowedBook)
        {
            borrowedBookRepository.CreateBorrowedBook(borrowedBook);
        }
        public void DeleteBorrowedBook(int id)
        {
            borrowedBookRepository.DeleteBorrowedBook(id);
        }
        public void UpdateBorrowedBook(Borrowedbook borrowedBook)
        {
            borrowedBookRepository.UpdateBorrowedBook(borrowedBook);
        }
        public Borrowedbook GetBorrowedBookById(int id)
        {
            return borrowedBookRepository.GetBorrowedBookById(id);
        }

        public List<BorrowedBooksDetails> GetBorrowedBooksDetails()
        {
            return borrowedBookRepository.GetBorrowedBooksDetails();
        }
    
    }
}
