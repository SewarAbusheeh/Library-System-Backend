using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
   

        [Route("api/[controller]")]
        [ApiController]
        public class ContactUsPageController : ControllerBase
        {
            private readonly IContactUsPageService contactUsPageService;

            public ContactUsPageController(IContactUsPageService contactUsPageService)
            {
                this.contactUsPageService = contactUsPageService;
            }

            [HttpGet]
            [Route("GetAllContactUsPageData")]
            public ActionResult<List<Contactuspage>> GetAllContactUsPageData()
            {
                return contactUsPageService.GetAllContactUsPageData();
            }

            [HttpGet]
            [Route("GetContactUsPageDataById/{id}")]
            public ActionResult<Contactuspage> GetContactUsPageDataById(int id)
            {
                var contactUsPage = contactUsPageService.GetContactUsPageDataById(id);
                if (contactUsPage == null)
                {
                    return NotFound();
                }
                return contactUsPage;
            }

            [HttpPost]
            [Route("CreateContactUsPageData")]
            public IActionResult CreateContactUsPageData(Contactuspage contactUsPage)
            {
                contactUsPageService.CreateContactUsPageData(contactUsPage);
                return CreatedAtAction(nameof(GetContactUsPageDataById), new { id = contactUsPage.CONTACTUSPAGE_ID }, contactUsPage);
            }

            [HttpPut]
            [Route("UpdateContactUsPageData")]
            public IActionResult UpdateContactUsPageData(Contactuspage contactUsPage)
            {
                contactUsPageService.UpdateContactUsPageData(contactUsPage);
                return NoContent();
            }

            [HttpDelete]
            [Route("DeleteContactUsPageData/{id}")]
            public IActionResult DeleteContactUsPageData(int id)
            {
                contactUsPageService.DeleteContactUsPageData(id);
                return NoContent();
            }
        }
    }

