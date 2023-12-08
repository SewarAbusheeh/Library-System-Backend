using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Service;
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
        [Route("GetAllContactUsRequests")]
        public List<Contactu> GetAllContactUsRequests()
        {
            return contactusService.GetAllContactUsRequests();
        }
        [HttpGet]
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
        public void UpdateContactUsRequest(Contactu contactus)
        {
            contactusService.UpdateContactUsRequest(contactus);
        }

        [HttpDelete]
        [Route("DeleteContactUsRequest")]
        public void DeleteContactUsRequest(int id)
        {
           contactusService.DeleteContactUsRequest(id);
        }
    }
}
