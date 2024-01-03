using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [Route("CreateUser")]
        [HttpPost]
        public void CreatUser(User user) {
            userService.CreateUser(user);
        }
        [Route("DeleteUser")]
        [HttpDelete]
        public void DeleteUser(int id) {
            userService.DeleteUser(id);
        }
        [Route("UpdateUser")]
        [HttpPut]
        public void UpdateUser(int id,User user) {
            userService.UpdateUser(id,user);
        }
        [Route("GetAllUsers")]
        [HttpGet]
        public List<User> GetAllUsers() { 
            return userService.GetAllUsers();
        }
        [Route("GetUserById")]
        [HttpGet]
        public User GetUserById(int id) { 
            return userService.GetUserById(id);
        }
    }
}
