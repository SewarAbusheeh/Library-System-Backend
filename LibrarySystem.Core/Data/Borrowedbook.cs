using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Borrowedbook
    {
        public Borrowedbook()
        {
            BookReviews = new HashSet<BookReview>();
        }

        public decimal Borrow_Id { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Book_Id { get; set; }
        public DateTime? Borrow_Date_From { get; set; }
        public DateTime? Borrow_Date_To { get; set; }
        public DateTime? Returned_Date { get; set; }
        public decimal? Fine_Percentage { get; set; }
        public string? Isfine_Paid { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }
    }
}
