using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsPageController : ControllerBase
    {
        private readonly IAboutUsPageService aboutUsPageService;

        public AboutUsPageController(IAboutUsPageService aboutUsPageService)
        {
            this.aboutUsPageService = aboutUsPageService;
        }

        [HttpGet]
        [Route("GetAllAboutUsPageData")]
        public ActionResult<List<Aboutuspage>> GetAllAboutUsPageData()
        {
            return aboutUsPageService.GetAllAboutUsPageData();
        }

        [HttpGet]
        [Route("GetAboutUsPageDataById/{id}")]
        public ActionResult<Aboutuspage> GetAboutUsPageDataById(int id)
        {
            var aboutUsPage = aboutUsPageService.GetAboutUsPageDataById(id);
            if (aboutUsPage == null)
            {
                return NotFound();
            }
            return aboutUsPage;
        }

        [HttpPost]
        [Route("CreateAboutUsPageData")]
        public IActionResult CreateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            aboutUsPageService.CreateAboutUsPageData(aboutUsPage);
            return CreatedAtAction(nameof(GetAboutUsPageDataById), new { id = aboutUsPage.ABOUTUSPAGE_ID }, aboutUsPage);
        }

        [HttpPut]
        [Route("UpdateAboutUsPageData")]
        public IActionResult UpdateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            aboutUsPageService.UpdateAboutUsPageData(aboutUsPage);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteAboutUsPageData/{id}")]
        public IActionResult DeleteAboutUsPageData(int id)
        {
            aboutUsPageService.DeleteAboutUsPageData(id);
            return NoContent();
        }
    }
}
