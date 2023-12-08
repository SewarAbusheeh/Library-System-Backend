using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService bankService;
        public BankController (IBankService _bankService)
        {
            this.bankService = _bankService;
        }

        [HttpGet]
        [Route("GetAllBankAccounts")]
        public List<Bank> GetAllBankAccounts()
        {
            return bankService.GetAllBankAccounts();
        }
        [HttpGet]
        [Route("GetBankAccountById/{id}")]
        public Bank GetBankAccountById(int id)
        {
           return bankService.GetBankAccountById(id);
        }
        [HttpPost]
        [Route("CreateBankAccount")]
        public void CreateBankAccount(Bank bank)
        {
            bankService.CreateBankAccount(bank);
        }
        [HttpPut]
        [Route("UpdateBankAccount")]
        public void UpdateBankAccount(Bank bank)
        {
            bankService.UpdateBankAccount(bank);
        }

        [HttpDelete]
        [Route("DeleteBankAccount")]
        public void DeleteBankAccount(int id)
        {
            bankService.DeleteBankAccount(id);
        }

    }
}
