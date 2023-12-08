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
    public interface IContactusRepository
    {
        List<Contactu> GetAllContactUsRequests();
         Contactu GetContactUsRequestById(int id);
       
        void CreateContactUsRequest(Contactu contactus);
        void UpdateContactUsRequest(Contactu contactus);
        void DeleteContactUsRequest(int id);
       
    }
}
