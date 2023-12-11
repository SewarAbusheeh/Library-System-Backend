using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        public TestimonialService(ITestimonialRepository _testimonialRepository)
        {
            testimonialRepository = _testimonialRepository;
        }
        public void CreateTestimonial(Testimonial testimonial)
        {
            testimonialRepository.CreateTestimonial(testimonial);
        }

        public void DeleteTestimonial(int id)
        {
            testimonialRepository.DeleteTestimonial(id);
        }

        public List<Testimonial> GetAllTestimonails()
        {
            return testimonialRepository.GetAllTestimonails();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return testimonialRepository.GetTestimonialById(id);
        }

        public void UpdateTestimonial(int id, Testimonial testimonial)
        {
            testimonialRepository.UpdateTestimonial(id, testimonial);
        }
    }
}
