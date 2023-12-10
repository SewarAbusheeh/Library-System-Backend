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
    public class AboutUsPageRepository : IAboutUsPageRepository
    {
        private readonly IDbContext dbContext;

        public AboutUsPageRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Aboutuspage> GetAllAboutUsPageData()
        {
            IEnumerable<Aboutuspage> result = dbContext.Connection.Query<Aboutuspage>("ABOUTUSPAGE_PACKAGE.GetAllAboutUsPageEntries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
        public Aboutuspage GetAboutUsPageDataById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutUsPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Aboutuspage>("ABOUTUSPAGE_PACKAGE.GetAboutUsPageEntryById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            var p = new DynamicParameters();
            p.Add("p_logoPath", aboutUsPage.LOGO_PATH, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", aboutUsPage.HEADER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", aboutUsPage.HEADER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", aboutUsPage.HEADER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", aboutUsPage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", aboutUsPage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", aboutUsPage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", aboutUsPage.FOOTER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", aboutUsPage.FOOTER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", aboutUsPage.FOOTER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", aboutUsPage.IMAGE_PATH1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", aboutUsPage.IMAGE_PATH2, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("ABOUTUSPAGE_PACKAGE.CreateAboutUsPageEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutUsPageId", aboutUsPage.ABOUTUSPAGE_ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_logoPath", aboutUsPage.LOGO_PATH, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", aboutUsPage.HEADER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", aboutUsPage.HEADER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", aboutUsPage.HEADER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", aboutUsPage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", aboutUsPage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", aboutUsPage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", aboutUsPage.FOOTER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", aboutUsPage.FOOTER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", aboutUsPage.FOOTER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", aboutUsPage.IMAGE_PATH1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", aboutUsPage.IMAGE_PATH2, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("ABOUTUSPAGE_PACKAGE.UpdateAboutUsPageEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAboutUsPageData(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutUsPageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("ABOUTUSPAGE_PACKAGE.DeleteAboutUsPageEntry", p, commandType: CommandType.StoredProcedure);
        }
    }


}
