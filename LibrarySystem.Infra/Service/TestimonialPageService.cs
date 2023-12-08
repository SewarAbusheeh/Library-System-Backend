using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class TestimonialPageService:ITestimonialPageService
    {
        private readonly ITestimonialPageRepository testimonialPageRepository;
        public TestimonialPageService(ITestimonialPageRepository testimonialPageRepository)
        {
            this.testimonialPageRepository = testimonialPageRepository;
        }

        public List<Testimonialpage> GetAllTestimonialPageData()
        {
            return testimonialPageRepository.GetAllTestimonialPageData();
        }

        public Testimonialpage GetTestimonialPageDataById(int id)
        {
            return testimonialPageRepository.GetTestimonialPageDataById(id);
        }
        public void CreateTestimonialPageData(Testimonialpage testimonialpage)
        {
            testimonialPageRepository.CreateTestimonialPageData(testimonialpage);
        }
        public void UpdateTestimonialPageData(Testimonialpage testimonialpage)
        {
            testimonialPageRepository.UpdateTestimonialPageData(testimonialpage);
        }

        public void DeleteTestimonialPageData(int id)
        {
           testimonialPageRepository.DeleteTestimonialPageData(id);
        }
    }
}
