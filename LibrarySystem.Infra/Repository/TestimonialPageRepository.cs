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
            IEnumerable<Testimonialpage> result = dbContext.Connection.Query<Testimonialpage>("TESTIMONIALPAGE_PACKAGE.GetAllTestimonialPageEntries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
        public Testimonialpage GetTestimonialPageDataById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Testimonialpage>("TESTIMONIALPAGE_PACKAGE.GetTestimonialPageEntryById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateTestimonialPageData(Testimonialpage testimonialpage)
        {
            var p = new DynamicParameters();
            p.Add("p_title", testimonialpage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", testimonialpage.Header_Component1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", testimonialpage.Header_Component2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", testimonialpage.Header_Component3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", testimonialpage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", testimonialpage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", testimonialpage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", testimonialpage.Footer_Component1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", testimonialpage.Footer_Component2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", testimonialpage.Footer_Component3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", testimonialpage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", testimonialpage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TESTIMONIALPAGE_PACKAGE.CreateTestimonialPageEntry", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateTestimonialPageData(Testimonialpage testimonialpage)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", testimonialpage.Testimonialpage_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", testimonialpage.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", testimonialpage.Header_Component1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", testimonialpage.Header_Component2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", testimonialpage.Header_Component3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", testimonialpage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", testimonialpage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", testimonialpage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", testimonialpage.Footer_Component1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", testimonialpage.Footer_Component2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", testimonialpage.Footer_Component3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", testimonialpage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", testimonialpage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TESTIMONIALPAGE_PACKAGE.UpdateTestimonialPageEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonialPageData(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_testimonialPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contactu>("TESTIMONIALPAGE_PACKAGE.DeleteTestimonialPageEntry", p, commandType: CommandType.StoredProcedure);
        }
    }
}
