using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
