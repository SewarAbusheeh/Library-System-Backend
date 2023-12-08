using LibrarySystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Repository
{
    public interface ILibraryRepository
    {
        void CreateLibrary(Library library);
        void UpdateLibrary(int id, Library library);
        void DeleteLibrary(int id);
        List<Library> GetAllLibraries();
        Library GetLibraryById(int id);
    }
}
