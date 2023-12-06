using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Contactuspage
    {
        public decimal ContactuspageId { get; set; }
        public string? LogoPath { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? HeaderComponent1 { get; set; }
        public string? HeaderComponent2 { get; set; }
        public string? HeaderComponent3 { get; set; }
        public string? Paragraph1 { get; set; }
        public string? Paragraph2 { get; set; }
        public string? Paragraph3 { get; set; }
        public string? FooterComponent1 { get; set; }
        public string? FooterComponent2 { get; set; }
        public string? FooterComponent3 { get; set; }
    }
}
