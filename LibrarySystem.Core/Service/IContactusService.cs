using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IContactusService
    {
        List<Contactu> GetAllContactUsRequests();
        Contactu GetContactUsRequestById(int id);

        void CreateContactUsRequest(Contactu contactus);
        void UpdateContactUsRequest(Contactu contactus);
        void DeleteContactUsRequest(int id);
    }
}
