using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public interface ITestimonialRepository
    {
        void CreateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
        void UpdateTestimonial(int id,Testimonial testimonial);
        List<Testimonial>GetAllTestimonails();
        Testimonial GetTestimonialById(int id);
    }
}
