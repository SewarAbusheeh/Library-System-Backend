using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface IAboutUsPageService
    {
        List<Aboutuspage> GetAllAboutUsPageData();
        Aboutuspage GetAboutUsPageDataById(int id);
        void CreateAboutUsPageData(Aboutuspage aboutUsPage);
        void UpdateAboutUsPageData(Aboutuspage aboutUsPage);
        void DeleteAboutUsPageData(int id);
    }

}
