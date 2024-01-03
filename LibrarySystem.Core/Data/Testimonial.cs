using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonials_Id { get; set; }
        public DateTime? Submission_Date { get; set; }
        public string? Status { get; set; }
        public string? Text { get; set; }
        public decimal? User_Id { get; set; }

        public virtual User? User { get; set; }
    }
}
