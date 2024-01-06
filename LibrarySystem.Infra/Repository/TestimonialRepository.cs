using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext context;
        public TestimonialRepository(IDbContext _context)
        {
            context = _context;
        }
        public void CreateTestimonial(Testimonial testimonial)
        {
            var t = new DynamicParameters();
            t.Add("p_submissionDate",testimonial.Submission_Date,dbType:DbType.Date,direction:ParameterDirection.Input);
            t.Add("p_status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            t.Add("p_text",testimonial.Text,dbType:DbType.String,direction:ParameterDirection.Input);
            t.Add("p_userId",testimonial.User_Id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = context.Connection.Execute("Testimonials_Package.CreateTestimonial",t,commandType:CommandType.StoredProcedure);
        }

        public void DeleteTestimonial(int id)
        {
            var t = new DynamicParameters();
            t.Add("p_testimonialId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = context.Connection.Execute("Testimonials_Package.DeleteTestimonial",t,commandType:CommandType.StoredProcedure);
        }

        public List<Testimonial> GetAllTestimonails()
        {
            IEnumerable<Testimonial> result = context.Connection.Query<Testimonial>("Testimonials_Package.GetAllTestimonials",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetTestimonialById(int id)
        {
            var t=new DynamicParameters();
            t.Add("p_testimonialId", id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = context.Connection.Query<Testimonial>("Testimonials_Package.GetTestimonialById",t,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateTestimonial(int id, Testimonial testimonial)
        {
            var t=new DynamicParameters();
            t.Add("p_testimonialId",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            t.Add("p_submissionDate",testimonial.Submission_Date,dbType:DbType.DateTime,direction:ParameterDirection.Input);
            t.Add("p_status",testimonial.Status,dbType:DbType.String,direction:ParameterDirection.Input);
            t.Add("p_text",testimonial.Text,dbType:DbType.String,direction:ParameterDirection.Input);
            t.Add("p_userId",testimonial.User_Id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = context.Connection.Execute("Testimonials_Package.UpdateTestimonial",t,commandType:CommandType.StoredProcedure);
        }
    }
}
