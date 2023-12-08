using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Bank
    {
        public decimal Card_Id { get; set; }
        public decimal? Card_No { get; set; }
        public string? Cardholder_Name { get; set; }
        public decimal? Balance { get; set; }
        public string? Cvv { get; set; }
    }
}
