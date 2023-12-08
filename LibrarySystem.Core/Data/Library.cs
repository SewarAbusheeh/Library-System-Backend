using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Library
    {
        public Library()
        {
            Categories = new HashSet<Category>();
        }

        public decimal Library_Id { get; set; }
        public string? Name { get; set; }
        public string? Location_Latitude { get; set; }
        public string? Location_Longitude { get; set; }
        public string? Phone_Number { get; set; }
        public string? Image_Path1 { get; set; }
        public string? Image_Path2 { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
