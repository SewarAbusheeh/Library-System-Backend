using LibrarySystem.Core.Data;
using LibrarySystem.Core.Service;
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
        public Testimonial GetTestimonialById(int id) {
            return testimonialService.GetTestimonialById(id);
        }
        [Route("DeleteTestimonial")]
        [HttpDelete]
        public void DeleteTestimonial(int id) {
            testimonialService.DeleteTestimonial(id);
        }
        [Route("CreateTestimonial")]
        [HttpPost]
        public void CreateTestimonial(Testimonial testimonial)
        {
            testimonialService.CreateTestimonial(testimonial);
        }
        [Route("UpdateTestimonial")]
        [HttpPut]
        public void UpdateTestimonial(int id,Testimonial testimonial) {
            testimonialService.UpdateTestimonial(id, testimonial);
        }

    }
}
