using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public List<Bank> GetAllBankAccounts()
        {
            return bankService.GetAllBankAccounts();
        }
        [HttpGet]
        [Route("GetBankAccountById/{id}")]
        [Authorize]
        [RequiresClaim("roleid", "1")]
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
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void UpdateBankAccount(Bank bank)
        {
            bankService.UpdateBankAccount(bank);
        }

        [HttpDelete]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        [Route("DeleteBankAccount")]
        public void DeleteBankAccount(int id)
        {
            bankService.DeleteBankAccount(id);
        }

    }
}
