using System;
using System.Collections.Generic;

namespace LibrarySystem.API.Data
{
    public partial class Bank
    {
        public decimal CardId { get; set; }
        public decimal? CardNo { get; set; }
        public string? CardholderName { get; set; }
        public decimal? Balance { get; set; }
        public string? Cvv { get; set; }
    }
}
