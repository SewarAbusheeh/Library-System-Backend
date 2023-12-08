using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class BankService:IBankService
    {
        private readonly IBankRepository bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public List<Bank> GetAllBankAccounts()
        {
            return bankRepository.GetAllBankAccounts();
        }
        public Bank GetBankAccountById(int id)
        {
           return bankRepository.GetBankAccountById(id);
        }
        public void CreateBankAccount(Bank bank)
        {
            bankRepository.CreateBankAccount(bank);
        }

        public void UpdateBankAccount(Bank bank)
        {
            bankRepository.UpdateBankAccount(bank);
        }


        public void DeleteBankAccount(int id)
        {
            bankRepository.DeleteBankAccount(id);
        }
    }
}
