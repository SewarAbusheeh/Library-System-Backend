using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IRoleService
    {
        void CreateRole(Role role);
        void UpdateRole(int id, Role role);
        void DeleteRole(int id);
        List<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}
