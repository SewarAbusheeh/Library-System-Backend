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
    public class ContactusRepository: IContactusRepository
    {

        private readonly IDbContext dbContext;

        public ContactusRepository(IDbContext _dbContext)
        {

            this.dbContext = _dbContext;
        }
        public List<Contactu> GetAllContactUsRequests()
        {
            IEnumerable<Contactu> result = dbContext.Connection.Query<Contactu>("CONTACTUS_PACKAGE.GetAllContactUsEntries", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contactu GetContactUsRequestById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_contactUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contactu>("CONTACTUS_PACKAGE.GetContactUsEntryById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateContactUsRequest(Contactu contactus)
        {
            var p = new DynamicParameters();
            p.Add("p_fullName", contactus.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_phoneNumber", contactus.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_subject", contactus.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_message", contactus.Message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CONTACTUS_PACKAGE.CreateContactUsEntry", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateContactUsRequest(Contactu contactus)
        {
            var p = new DynamicParameters();
            p.Add("p_contactUsId", contactus.ContactusId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_fullName", contactus.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_phoneNumber", contactus.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_subject", contactus.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_message", contactus.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("CONTACTUS_PACKAGE.UpdateContactUsEntry", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteContactUsRequest(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_contactUsId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Contactu>("CONTACTUS_PACKAGE.DeleteContactUsEntry", p, commandType: CommandType.StoredProcedure);
        }


    }
}
