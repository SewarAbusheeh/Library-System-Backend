using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.DTO
{
    public  class BookWithCategory
    {
        public decimal Book_Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Book_Img_Path { get; set; }
        public string? Book_Pdf_Path { get; set; }
        public DateTime? Publication_Date { get; set; }
        public decimal? Price_Per_Day { get; set; }
        public decimal? Avg_Rating { get; set; }

        public string? Category_Name { get; set; }
    }
}
