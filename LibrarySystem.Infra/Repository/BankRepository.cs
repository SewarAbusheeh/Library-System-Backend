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
   public class BankRepository:IBankRepository
    {
        private readonly IDbContext dbContext;

        public BankRepository(IDbContext _dbContext){

            this.dbContext = _dbContext;
        }

        public List<Bank> GetAllBankAccounts()
        {
            IEnumerable<Bank> result = dbContext.Connection.Query<Bank>("BANK_PACKAGE.GetAllBankCards", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        /*GetBankCardById(p_cardId IN NUMBER);
  PROCEDURE CreateBankCard(p_cardNo IN NUMBER, p_cardholderName IN bank.cardholder_name%TYPE, p_balance IN FLOAT, p_cvv IN bank.cvv%TYPE);
  PROCEDURE UpdateBankCard(p_cardId IN NUMBER, p_cardNo IN NUMBER, p_cardholderName IN bank.cardholder_name%TYPE, p_balance IN FLOAT, p_cvv IN bank.cvv%TYPE);
  PROCEDURE DeleteBankCard(p_cardId IN NUMBER);*/
        public Bank GetBankAccountById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_cardId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Bank>("BANK_PACKAGE.GetBankCardById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public void CreateBankAccount(Bank bank)
        {
            var p = new DynamicParameters();
            p.Add("p_cardNo", bank.Card_No, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_cardholderName", bank.Cardholder_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_balance", bank.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("p_cvv", bank.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("BANK_PACKAGE.CreateBankCard", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBankAccount(Bank bank)
        {
            var p = new DynamicParameters();
            p.Add("p_cardId", bank.Card_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_cardNo", bank.Card_No, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_cardholderName", bank.Cardholder_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_balance", bank.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("p_cvv", bank.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("BANK_PACKAGE.UpdateBankCard", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBankAccount(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_cardId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("BANK_PACKAGE.DeleteBankCard", p, commandType: CommandType.StoredProcedure);
        }
    }
}
