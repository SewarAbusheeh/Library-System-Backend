using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }
        public void CreateRole(Role role)
        {
            roleRepository.CreateRole(role);
        }

        public void DeleteRole(int id)
        {
            roleRepository.DeleteRole(id);
        }

        public List<Role> GetAllRoles()
        {
            return roleRepository.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return roleRepository.GetRoleById(id);
        }

        public void UpdateRole(int id, Role role)
        {
            roleRepository.UpdateRole(id, role);
        }
    }
}
