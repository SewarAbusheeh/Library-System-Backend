using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Service
{
    public interface ILibraryService
    {
        void CreateLibrary(Library library);
        void UpdateLibrary(int id, Library library);
        void DeleteLibrary(int id);
        List<Library> GetAllLibraries();
        Library GetLibraryById(int id);
        List<BorrowedBooks_LibraryDTO> GetBorrowedBooksCountInLibraries();
    }
}
