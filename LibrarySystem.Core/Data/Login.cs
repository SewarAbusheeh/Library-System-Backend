using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Login
    {
        public decimal LoginId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Role_Id { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
