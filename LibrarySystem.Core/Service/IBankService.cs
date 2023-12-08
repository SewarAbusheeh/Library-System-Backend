using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IBankService
    {
        List<Bank> GetAllBankAccounts();
        Bank GetBankAccountById(int id);
        void CreateBankAccount(Bank bank);
        void UpdateBankAccount(Bank bank);
        void DeleteBankAccount(int id);
    }
}
