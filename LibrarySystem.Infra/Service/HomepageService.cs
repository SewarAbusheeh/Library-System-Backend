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
    public class HomepageService   : IHomepageService
    {
        private readonly IHomepageRepository homePageRepository;

        public HomepageService(IHomepageRepository homePageRepository)
        {
            this.homePageRepository = homePageRepository;
        }

        public List<Homepage> GetAllHomePageData()
        {
            return homePageRepository.GetAllHomePageData();
        }

        public Homepage GetHomePageDataById(int id)
        {
            return homePageRepository.GetHomePageDataById(id);
        }

        public void CreateHomePageData(Homepage homePage)
        {
            homePageRepository.CreateHomePageData(homePage);
        }

        public void UpdateHomePageData(Homepage homePage)
        {
            homePageRepository.UpdateHomePageData(homePage);
        }

        public void DeleteHomePageData(int id)
        {
            homePageRepository.DeleteHomePageData(id);
        }
    }
}
