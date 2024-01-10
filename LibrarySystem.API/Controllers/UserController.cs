using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
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
        
        [Route("NumberOfRegisteredUsers")]
        [HttpGet]
        public int NumberOfRegisteredUsers()
        {
            return userService.NumberOfRegisteredUsers();   
        }
        [Route("GetUsersWithReservations")]
        [HttpGet]
        public List<UsersWithReservations> GetUsersWithReservations()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\Fron-End Fixe upload images\\LibrarySystemFrontEnd\\src\\assets\\UserImages", fileName);
            return userService.GetUsersWithReservations();
        }

            [Route("uploadImage")]
            [HttpPost]
            public User UploadIMage()
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\ahmad\\OneDrive\\Documents\\VSC\\FinalProject\\LibrarySystemFrontEnd\\src\\assets\\UserImages", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                User item = new User();
                item.Profile_Img_Path = fileName;
                return item;
            }
        }
    }

