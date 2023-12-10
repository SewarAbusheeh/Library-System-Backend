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
    public  class HomepageRepository  : IHomepageRepository
    {
        private readonly IDbContext dbContext;

        public HomepageRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public List<Homepage> GetAllHomePageData()
        {
            IEnumerable<Homepage> result = dbContext.Connection.Query<Homepage>("HOMEPAGE_PACKAGE.GetAllHomePageEntries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Homepage GetHomePageDataById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_homePageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Homepage>("HOMEPAGE_PACKAGE.GetHomePageEntryById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void CreateHomePageData(Homepage homePage)
        {
            var p = new DynamicParameters();
            p.Add("p_logoPath", homePage.LOGO_PATH, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_title", homePage.TITLE, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", homePage.FOOTER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent2", homePage.FOOTER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent3", homePage.FOOTER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph1", homePage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph2", homePage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_paragraph3", homePage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent1", homePage.FOOTER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", homePage.FOOTER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", homePage.FOOTER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", homePage.IMAGE_PATH1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", homePage.IMAGE_PATH2, dbType: DbType.String, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("HOMEPAGE_PACKAGE.CreateHomePageEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateHomePageData(Homepage homePage)
        {
            var p = new DynamicParameters();
            p.Add("p_homePageId", homePage.HOMEPAGE_ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_logoPath", homePage.LOGO_PATH, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_title", homePage.TITLE, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_headerComponent1", homePage.HEADER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected from FOOTER_COMPONENT1
            p.Add("p_headerComponent2", homePage.HEADER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected from FOOTER_COMPONENT2
            p.Add("p_headerComponent3", homePage.HEADER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected from FOOTER_COMPONENT3
            p.Add("p_paragraph1", homePage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected to PARAGRAPH1
            p.Add("p_paragraph2", homePage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected to PARAGRAPH2
            p.Add("p_paragraph3", homePage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input); // Corrected to PARAGRAPH3
            p.Add("p_footerComponent1", homePage.FOOTER_COMPONENT1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent2", homePage.FOOTER_COMPONENT2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_footerComponent3", homePage.FOOTER_COMPONENT3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath1", homePage.IMAGE_PATH1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_imagePath2", homePage.IMAGE_PATH2, dbType: DbType.String, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("HOMEPAGE_PACKAGE.UpdateHomePageEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHomePageData(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_homePageId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("HOMEPAGE_PACKAGE.DeleteHomePageEntry", p, commandType: CommandType.StoredProcedure);
        }
    }
}
