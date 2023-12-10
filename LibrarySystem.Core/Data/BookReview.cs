using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class BookReview
    {
        public decimal Book_Review_Id { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Book_Id { get; set; }
        public decimal? Borrow_Id { get; set; }
        public decimal? Rating { get; set; }
        public string? Review_Text { get; set; }
        public DateTime? Review_Date { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Borrowedbook? Borrow { get; set; }
        public virtual User? User { get; set; }
    }
}
