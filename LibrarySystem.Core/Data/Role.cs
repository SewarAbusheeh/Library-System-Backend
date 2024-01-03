using System;
using System.Collections.Generic;

namespace LibrarySystem.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Role_Id { get; set; }
        public string? Role_Name { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
