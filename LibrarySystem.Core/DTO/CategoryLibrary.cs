using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
   public class CategoryLibrary
    {
        public decimal Category_Id { get; set; }
        public string? Category_Name { get; set; }
        public decimal? Library_Id { get; set; }

        public string? Name { get; set; }
    }
}
