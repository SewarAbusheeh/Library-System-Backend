using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class User
    {
        public User()
        {
            BookReviews = new HashSet<BookReview>();
            Borrowedbooks = new HashSet<Borrowedbook>();
            Logins = new HashSet<Login>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfileImgPath { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? IsActivated { get; set; }

        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<Borrowedbook> Borrowedbooks { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
