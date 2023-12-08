using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public  interface IBankRepository
    {
        List<Bank> GetAllBankAccounts();
        Bank GetBankAccountById(int id);
        void CreateBankAccount(Bank bank);
        void UpdateBankAccount(Bank bank);
        void DeleteBankAccount(int id);
    }
}
