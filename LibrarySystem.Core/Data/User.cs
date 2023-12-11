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

        public decimal User_Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Location_Latitude { get; set; }
        public string? Location_Longitude { get; set; }
        public string? Phone_Number { get; set; }
        public string? Profile_Img_Path { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string? Is_Activated { get; set; }

        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<Borrowedbook> Borrowedbooks { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
