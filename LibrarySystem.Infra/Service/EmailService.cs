using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LibrarySystem.Core.Common;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySystem.Infra.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository emailRepositoy;

        public EmailService(IEmailRepository emailRepositoy)
        {
            this.emailRepositoy = emailRepositoy;
        }

        public void SendEmail(GetBorrowedBooksDetailsByUserIdDTO borrowedBooks)
        {
            emailRepositoy.SendEmail(borrowedBooks);
        }
    }
}
