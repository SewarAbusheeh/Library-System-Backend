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
    public class ContactUsPageRepository : IContactUsPageRepository
    {
        private readonly IDbContext dbContext;

        public ContactUsPageRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        // Method to get all ContactUsPage entries
        public List<Contactuspage> GetAllContactUsPageData()
        {
            var result = dbContext.Connection.Query<Contactuspage>("ContactUsPage_Package.GetAllContactUsPageEntries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Method to get a single ContactUsPage entry by ID
        public Contactuspage GetContactUsPageDataById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_contactUsPageId", id, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.QueryFirstOrDefault<Contactuspage>("ContactUsPage_Package.GetContactUsPageEntryById", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        // Method to create a new ContactUsPage entry
        public void CreateContactUsPageData(Contactuspage contactUsPage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_logoPath", contactUsPage.LOGO_PATH, DbType.String, ParameterDirection.Input);
            parameters.Add("p_email", contactUsPage.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("p_subject", contactUsPage.Subject, DbType.String, ParameterDirection.Input);
            parameters.Add("p_message", contactUsPage.Message, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent1", contactUsPage.HEADER_COMPONENT1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent2", contactUsPage.HEADER_COMPONENT2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent3", contactUsPage.HEADER_COMPONENT3, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph1", contactUsPage.Paragraph1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph2", contactUsPage.Paragraph2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph3", contactUsPage.Paragraph3, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent1", contactUsPage.FOOTER_COMPONENT1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent2", contactUsPage.FOOTER_COMPONENT2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent3", contactUsPage.FOOTER_COMPONENT3, DbType.String, ParameterDirection.Input);
           

            dbContext.Connection.Execute("ContactUsPage_Package.CreateContactUsPageEntry", parameters, commandType: CommandType.StoredProcedure);
        }

        // Method to update an existing ContactUsPage entry
        public void UpdateContactUsPageData(Contactuspage contactUsPage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_contactUsPageId", contactUsPage.CONTACTUSPAGE_ID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("p_logoPath", contactUsPage.LOGO_PATH, DbType.String, ParameterDirection.Input);
            parameters.Add("p_email", contactUsPage.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("p_subject", contactUsPage.Subject, DbType.String, ParameterDirection.Input);
            parameters.Add("p_message", contactUsPage.Message, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent1", contactUsPage.HEADER_COMPONENT1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent2", contactUsPage.HEADER_COMPONENT2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_headerComponent3", contactUsPage.HEADER_COMPONENT3, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph1", contactUsPage.Paragraph1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph2", contactUsPage.Paragraph2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_paragraph3", contactUsPage.Paragraph3, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent1", contactUsPage.FOOTER_COMPONENT1, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent2", contactUsPage.FOOTER_COMPONENT2, DbType.String, ParameterDirection.Input);
            parameters.Add("p_footerComponent3", contactUsPage.FOOTER_COMPONENT3, DbType.String, ParameterDirection.Input);
           
            dbContext.Connection.Execute("ContactUsPage_Package.UpdateContactUsPageEntry", parameters, commandType: CommandType.StoredProcedure);
        }

        // Method to delete a ContactUsPage entry
        public void DeleteContactUsPageData(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_contactUsPageId", id, DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("ContactUsPage_Package.DeleteContactUsPageEntry", parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
