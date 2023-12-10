using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IHomepageService
    {
        void DeleteHomePageData(int id);
        List<Homepage> GetAllHomePageData();
        Homepage GetHomePageDataById(int id);
        void CreateHomePageData(Homepage homePage);
        void UpdateHomePageData(Homepage homePage);
    }
}
