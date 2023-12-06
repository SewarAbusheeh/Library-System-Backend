using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialsId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? Status { get; set; }
        public string? Text { get; set; }
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
