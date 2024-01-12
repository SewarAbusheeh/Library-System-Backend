using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Core.DTO;
namespace LibrarySystem.Core.Service
{
    public interface IEmailService
    {
        public void SendEmail(GetBorrowedBooksDetailsByUserIdDTO borrowedBooks);
    }
}
