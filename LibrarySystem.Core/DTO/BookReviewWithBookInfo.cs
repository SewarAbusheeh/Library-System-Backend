using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public class BookReviewWithBookInfo
    {
        public string Title { get; set; }
        public decimal Book_Review_Id { get; set; }
        public string USER_NAME { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Book_Id { get; set; }
        public decimal? Borrow_Id { get; set; }
        public decimal? Rating { get; set; }
        public string? Review_Text { get; set; }
        public DateTime? Review_Date { get; set; }
    }
}
