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

        public decimal CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal? LibraryId { get; set; }

        public virtual Library? Library { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
