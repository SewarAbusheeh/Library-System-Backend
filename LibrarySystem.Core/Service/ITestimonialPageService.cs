using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface ITestimonialPageService
    {
        List<Testimonialpage> GetAllTestimonialPageData();
        Testimonialpage GetTestimonialPageDataById(int id);
        void CreateTestimonialPageData(Testimonialpage testimonialpage);
        void UpdateTestimonialPageData(Testimonialpage testimonialpage);
        void DeleteTestimonialPageData(int id);
    }
}
