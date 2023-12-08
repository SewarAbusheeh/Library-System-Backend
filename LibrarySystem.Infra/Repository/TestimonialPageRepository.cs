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
   public class TestimonialPageRepository:ITestimonialPageRepository
    {
        private readonly IDbContext dbContext;
        public TestimonialPageRepository(IDbContext _dbContext)
        {

            this.dbContext = _dbContext;
        }
        public List<Testimonialpage> GetAllTestimonialPageData()
        {
            IEnumerable<Testimonialpage> result = dbContext.Connection.Query<Testimonialpage>("TESTIMONIALPAGE_PACKAGE.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
        public Testimonialpage GetTestimonialPageDataById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Testimonialpage>("TESTIMONIALPAGE_PACKAGE.GetTestimonialById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateTestimonialPageData(Testimonialpage testimonialpage)
        {
            var p = new DynamicParameters();
            p.Add("p_title", testimonialpage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", testimonialpage.HeaderComponent1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", testimonialpage.HeaderComponent2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", testimonialpage.HeaderComponent3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", testimonialpage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", testimonialpage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", testimonialpage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", testimonialpage.FooterComponent1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", testimonialpage.FooterComponent2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", testimonialpage.FooterComponent3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", testimonialpage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", testimonialpage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TESTIMONIALPAGE_PACKAGE.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateTestimonialPageData(Testimonialpage testimonialpage)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", testimonialpage.TestimonialpageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", testimonialpage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", testimonialpage.HeaderComponent1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", testimonialpage.HeaderComponent2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", testimonialpage.HeaderComponent3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", testimonialpage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", testimonialpage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", testimonialpage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", testimonialpage.FooterComponent1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", testimonialpage.FooterComponent2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", testimonialpage.FooterComponent3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", testimonialpage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", testimonialpage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TESTIMONIALPAGE_PACKAGE.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonialPageData(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contactu>("TESTIMONIALPAGE_PACKAGE.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
        }
    }
}
