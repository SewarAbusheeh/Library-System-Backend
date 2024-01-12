using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using LibrarySystem.Core.Service;
using LibrarySystem.Core.DTO;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public void SendEmail(GetBorrowedBooksDetailsByUserIdDTO borrowedBooks)
        {
           emailService.SendEmail(borrowedBooks);
        }
    }
}
