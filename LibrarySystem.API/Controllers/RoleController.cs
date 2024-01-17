using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }
        [Route("CreateRole")]
        [HttpPost]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void CreateRole(Role role) { 
            roleService.CreateRole(role);
        }
        [Route("UpdateRole")]
        [HttpPut]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateRole(int id,Role role) {
            roleService.UpdateRole(id,role);
        }
        [Route("DeleteRole")]
        [HttpDelete]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteRole(int id)
        {
            roleService.DeleteRole(id);
        }
        [Route("GetAllRoles")]
        [HttpGet]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public List<Role> GetAllRoles() {
            return roleService.GetAllRoles();
        }
        [Route("GetRoleById")]
        [HttpGet]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public Role GetRoleById(int id) {
            return roleService.GetRoleById(id);
        }
    }
}
