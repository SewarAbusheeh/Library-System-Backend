using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {
        private readonly IContactusService contactusService;
        public ContactusController(IContactusService contactusService)
        {
            this.contactusService = contactusService;
        }
        [HttpGet]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        [Route("GetAllContactUsRequests")]
        public List<Contactu> GetAllContactUsRequests()
        {
            return contactusService.GetAllContactUsRequests();
        }
        [HttpGet]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        [Route("GetBankAccountById/{id}")]
        public Contactu GetContactUsRequestById(int id)
        {
            return contactusService.GetContactUsRequestById(id);
        }
        [HttpPost]
        [Route("CreateContactUsRequest")]
        public void CreateContactUsRequest(Contactu contactus)
        {
            contactusService.CreateContactUsRequest(contactus);
        }
        [HttpPut]
        [Route("UpdateContactUsRequest")]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateContactUsRequest(Contactu contactus)
        {
            contactusService.UpdateContactUsRequest(contactus);
        }

        [HttpDelete]
        [Route("DeleteContactUsRequest")]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteContactUsRequest(int id)
        {
           contactusService.DeleteContactUsRequest(id);
        }
    }
}
