using Dapper;
using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class ContactusService: IContactusService
    {
        private readonly IContactusRepository contactusRepository;
        public ContactusService(IContactusRepository contactusRepository)
        {
            this.contactusRepository = contactusRepository;
        }
        public List<Contactu> GetAllContactUsRequests()
        {
           return contactusRepository.GetAllContactUsRequests();
        }
        public Contactu GetContactUsRequestById(int id)
        {

            return contactusRepository.GetContactUsRequestById(id);
        }
        public void CreateContactUsRequest(Contactu contactus)
        {
            contactusRepository.CreateContactUsRequest(contactus);
        }
        public void UpdateContactUsRequest(Contactu contactus)
        {
            contactusRepository.UpdateContactUsRequest(contactus);
        }

        public void DeleteContactUsRequest(int id)
        {
            contactusRepository.DeleteContactUsRequest(id);
        }
    }
}
