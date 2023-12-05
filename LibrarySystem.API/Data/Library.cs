using System;
using System.Collections.Generic;

namespace LibrarySystem.API.Data
{
    public partial class Library
    {
        public Library()
        {
            Categories = new HashSet<Category>();
        }

        public decimal LibraryId { get; set; }
        public string? Name { get; set; }
        public string? LocationLatitude { get; set; }
        public string? LocationLongitude { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath1 { get; set; }
        public string? ImagePath2 { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
