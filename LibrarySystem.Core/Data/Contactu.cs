using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Contactu
    {
        public decimal ContactusId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
