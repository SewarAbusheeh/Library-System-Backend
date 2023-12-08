using LibrarySystem.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
   public interface ITestimonialPageRepository
    {
         List<Testimonialpage> GetAllTestimonialPageData();
         Testimonialpage GetTestimonialPageDataById(int id);
         void CreateTestimonialPageData(Testimonialpage testimonialpage);
         void UpdateTestimonialPageData(Testimonialpage testimonialpage);
         void DeleteTestimonialPageData(int id);
        
    }
}
