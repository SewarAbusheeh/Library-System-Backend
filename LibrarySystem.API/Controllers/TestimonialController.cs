using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService _testimonialService)
        {
            testimonialService = _testimonialService;
        }
        [Route("GetAllTestimonials")]
        [HttpGet]
        public List<Testimonial> GetAllTestimonials() {
            return testimonialService.GetAllTestimonails();
        }
        [Route("GetTestimonialById")]
        [HttpGet]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public Testimonial GetTestimonialById(int id) {
            return testimonialService.GetTestimonialById(id);
        }
        [Route("DeleteTestimonial")]
        [HttpDelete]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteTestimonial(int id) {
            testimonialService.DeleteTestimonial(id);
        }
        [Route("CreateTestimonial")]
        [HttpPost]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void CreateTestimonial(Testimonial testimonial)
        {
            testimonialService.CreateTestimonial(testimonial);
        }
        [Route("UpdateTestimonial")]
        [HttpPut]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateTestimonial(int id,Testimonial testimonial) {
            testimonialService.UpdateTestimonial(id, testimonial);
        }

    }
}
