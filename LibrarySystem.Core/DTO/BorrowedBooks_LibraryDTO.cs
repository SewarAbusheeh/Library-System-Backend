using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public class BorrowedBooks_LibraryDTO
    {
        public string? Library_Name { get; set; }
        public decimal BORROWED_BOOKS_COUNT { get; set; }
    }
}
