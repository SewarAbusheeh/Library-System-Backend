using System;
using System.Collections.Generic;

namespace LibrarySystem.API.Data
{
    public partial class BookReview
    {
        public decimal BookReviewId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? BookId { get; set; }
        public decimal? BorrowId { get; set; }
        public string? Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Borrowedbook? Borrow { get; set; }
        public virtual User? User { get; set; }
    }
}
