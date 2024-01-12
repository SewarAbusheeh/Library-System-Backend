using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomepageController : ControllerBase
    {
        private readonly IHomepageService homePageService;

        public HomepageController(IHomepageService homePageService)
        {
            this.homePageService = homePageService;
        }

        [HttpGet]
        [Route("GetAllHomePageData")]
        public List<Homepage> GetAllHomePageData()
        {
            return homePageService.GetAllHomePageData();
        }

        [HttpGet]
        [Route("GetHomePageDataById/{id}")]
        public Homepage GetHomePageDataById(int id)
        {
            return homePageService.GetHomePageDataById(id);
        }

        [HttpPost]
        [Route("CreateHomePageData")]
        public void CreateHomePageData(Homepage homePage)
        {
            homePageService.CreateHomePageData(homePage);
        }

        [HttpPut]
        [Route("UpdateHomePageData")]
        public void UpdateHomePageData(Homepage homePage)
        {
            homePageService.UpdateHomePageData(homePage);
        }

        [HttpDelete]
        [Route("DeleteHomePageData/{id}")]
        public void DeleteHomePageData(int id)
        {
            homePageService.DeleteHomePageData(id);
        }


        [Route("uploadImage")]
        [HttpPost]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            if (file != null && (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png"))
            {
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\Amir Herzallah\\Desktop\\Tahaluf Internship\\01_Projects\\Final Project\\Angular\\LibrarySystem\\src\\assets\\images", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var response = new
                {
                    LogoPath = fileName,
                    Message = "File uploaded successfully."
                };
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid file format. Please upload an image file.");
            }
        }

    }
}
