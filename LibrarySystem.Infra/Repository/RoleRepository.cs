using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext context;
        public RoleRepository(IDbContext _context)
        {
            context = _context;
        }
        public void CreateRole(Role role)
        {
            var r =new DynamicParameters();
            r.Add("p_roleName", role.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.Connection.Execute("Roles_Package.CreateRole",r,commandType:CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var r=new DynamicParameters();
            r.Add("p_roleId",id,dbType:DbType.Int32,ParameterDirection.Input);
            var result = context.Connection.Execute("Roles_Package.DeleteRole",r,commandType:CommandType.StoredProcedure);
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = context.Connection.Query<Role>("Roles_Package.GetAllRoles",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var r=new DynamicParameters();
            r.Add("p_roleId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = context.Connection.Query<Role>("Roles_Package.GetRoleById",r,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateRole(int id, Role role)
        {
            var r=new DynamicParameters();
            r.Add("p_roleId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            r.Add("p_roleName", role.Role_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.Connection.Execute("Roles_Package.UpdateRole",r,commandType:CommandType.StoredProcedure);
        }
    }
}
