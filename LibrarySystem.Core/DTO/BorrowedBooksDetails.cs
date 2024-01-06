using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public  class BorrowedBooksDetails
    {

        public decimal Book_Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Book_Img_Path { get; set; }
        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Borrow_Date_From { get; set; }
        public DateTime? Borrow_Date_To { get; set; }
        public DateTime? Returned_Date { get; set; }
    }
}
