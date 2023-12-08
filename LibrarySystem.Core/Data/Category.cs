using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public decimal Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public decimal? Library_Id { get; set; }

        public virtual Library? Library { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
