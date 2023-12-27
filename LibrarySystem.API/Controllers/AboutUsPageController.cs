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
        public void UpdateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            aboutUsPageService.UpdateAboutUsPageData(aboutUsPage);
        }

        [HttpDelete]
        [Route("DeleteAboutUsPageData/{id}")]
        public IActionResult DeleteAboutUsPageData(int id)
        {
            aboutUsPageService.DeleteAboutUsPageData(id);
            return NoContent();
        }

        [Route("uploadImage")]
        [HttpPost]
        public Aboutuspage UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ahmad\\OneDrive\\Documents\\VSC\\FinalProject\\LibrarySystemFrontEnd\\src\\assets\\AboutUsImages", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Aboutuspage item = new Aboutuspage();
            item.IMAGE_PATH1 = fileName;
            return item;
        }
    }
}
