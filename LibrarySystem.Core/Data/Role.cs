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

        public decimal RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
