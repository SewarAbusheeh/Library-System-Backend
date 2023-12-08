using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Book
    {
        public Book()
        {
            BookReviews = new HashSet<BookReview>();
            Borrowedbooks = new HashSet<Borrowedbook>();
        }

        public decimal Book_Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Book_Img_Path { get; set; }
        public string? Book_Pdf_Path { get; set; }
        public DateTime? Publication_Date { get; set; }
        public decimal? Price_Per_Day { get; set; }
        public decimal? Avg_Rating { get; set; }
        public decimal? Category_Id { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<Borrowedbook> Borrowedbooks { get; set; }
    }
}
