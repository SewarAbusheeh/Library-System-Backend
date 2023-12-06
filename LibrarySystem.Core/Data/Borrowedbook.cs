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

        public decimal BorrowId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? BookId { get; set; }
        public DateTime? BorrowDateFrom { get; set; }
        public DateTime? BorrowDateTo { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public decimal? FinePercentage { get; set; }
        public string? IsfinePaid { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }
    }
}
