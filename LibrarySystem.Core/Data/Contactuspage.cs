using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Contactuspage
    {
        public decimal CONTACTUSPAGE_ID { get; set; }
        public string? LOGO_PATH { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? HEADER_COMPONENT1 { get; set; }
        public string? HEADER_COMPONENT2 { get; set; }
        public string? HEADER_COMPONENT3 { get; set; }
        public string? Paragraph1 { get; set; }
        public string? Paragraph2 { get; set; }
        public string? Paragraph3 { get; set; }
        public string? FOOTER_COMPONENT1 { get; set; }
        public string? FOOTER_COMPONENT2 { get; set; }
        public string? FOOTER_COMPONENT3 { get; set; }
    }
}
