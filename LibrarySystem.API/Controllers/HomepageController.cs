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
        public Homepage UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +
            "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Amir Herzallah\\Desktop\\Tahaluf Internship\\01_Projects\\Final Project\\Angular\\LibrarySystem\\src\\assets\\images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Homepage item = new Homepage();
            item.LOGO_PATH = fileName;
            return item;
        }
      
    }
}
