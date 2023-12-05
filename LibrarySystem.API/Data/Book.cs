using System;
using System.Collections.Generic;

namespace LibrarySystem.API.Data
{
    public partial class Book
    {
        public Book()
        {
            BookReviews = new HashSet<BookReview>();
            Borrowedbooks = new HashSet<Borrowedbook>();
        }

        public decimal BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? BookImgPath { get; set; }
        public string? BookPdfPath { get; set; }
        public string? PublicationDate { get; set; }
        public string? PricePerDay { get; set; }
        public string? AvgRating { get; set; }
        public decimal? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<Borrowedbook> Borrowedbooks { get; set; }
    }
}
