using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using LibrarySystem.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class ContactUsPageService : IContactUsPageService
    {
        private readonly IContactUsPageRepository contactUsPageRepository;

        public ContactUsPageService(IContactUsPageRepository contactUsPageRepository)
        {
            this.contactUsPageRepository = contactUsPageRepository;
        }

        public List<Contactuspage> GetAllContactUsPageData()
        {
            return contactUsPageRepository.GetAllContactUsPageData();
        }

        public Contactuspage GetContactUsPageDataById(int id)
        {
            return contactUsPageRepository.GetContactUsPageDataById(id);
        }

        public void CreateContactUsPageData(Contactuspage contactUsPage)
        {
            contactUsPageRepository.CreateContactUsPageData(contactUsPage);
        }

        public void UpdateContactUsPageData(Contactuspage contactUsPage)
        {
            contactUsPageRepository.UpdateContactUsPageData(contactUsPage);
        }

        public void DeleteContactUsPageData(int id)
        {
            contactUsPageRepository.DeleteContactUsPageData(id);
        }
    }

}
