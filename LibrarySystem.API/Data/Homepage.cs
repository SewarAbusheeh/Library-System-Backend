﻿using System;
using System.Collections.Generic;

namespace LibrarySystem.API.Data
{
    public partial class Homepage
    {
        public decimal HomepageId { get; set; }
        public string? LogoPath { get; set; }
        public string? Title { get; set; }
        public string? HeaderComponent1 { get; set; }
        public string? HeaderComponent2 { get; set; }
        public string? HeaderComponent3 { get; set; }
        public string? Paragraph1 { get; set; }
        public string? Paragraph2 { get; set; }
        public string? Paragraph3 { get; set; }
        public string? FooterComponent1 { get; set; }
        public string? FooterComponent2 { get; set; }
        public string? FooterComponent3 { get; set; }
        public string? ImagePath1 { get; set; }
        public string? ImagePath2 { get; set; }
    }
}
