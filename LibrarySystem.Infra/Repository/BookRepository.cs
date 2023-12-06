using LibrarySystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Repository
{
    public class BookRepository
    {
        private readonly IDbContext dbContext;

        public BookRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public void CreateBook(Book book)
    }
}
