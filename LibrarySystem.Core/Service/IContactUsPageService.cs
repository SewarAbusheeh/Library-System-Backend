using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IContactUsPageService
    {
        List<Contactuspage> GetAllContactUsPageData();
        Contactuspage GetContactUsPageDataById(int id);
        void CreateContactUsPageData(Contactuspage contactUsPage);
        void UpdateContactUsPageData(Contactuspage contactUsPage);
        void DeleteContactUsPageData(int id);
    }

}
