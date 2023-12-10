using LibrarySystem.Core.Data;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class AboutUsPageService : IAboutUsPageService 
    {
        private readonly IAboutUsPageRepository aboutUsPageRepository;

        public AboutUsPageService(IAboutUsPageRepository aboutUsPageRepository)
        {
            this.aboutUsPageRepository = aboutUsPageRepository;
        }

        public List<Aboutuspage> GetAllAboutUsPageData()
        {
            return aboutUsPageRepository.GetAllAboutUsPageData();
        }

        public Aboutuspage GetAboutUsPageDataById(int id)
        {
            return aboutUsPageRepository.GetAboutUsPageDataById(id);
        }

        public void CreateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            aboutUsPageRepository.CreateAboutUsPageData(aboutUsPage);
        }

        public void UpdateAboutUsPageData(Aboutuspage aboutUsPage)
        {
            aboutUsPageRepository.UpdateAboutUsPageData(aboutUsPage);
        }

        public void DeleteAboutUsPageData(int id)
        {
            aboutUsPageRepository.DeleteAboutUsPageData(id);
        }
    }
}
