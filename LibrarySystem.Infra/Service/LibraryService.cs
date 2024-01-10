using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using LibrarySystem.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infra.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public void CreateLibrary(Library library)
        {
            libraryRepository.CreateLibrary(library);
        }

        public void DeleteLibrary(int id)
        {
            libraryRepository.DeleteLibrary(id);
        }

        public List<Library> GetAllLibraries()
        {
            return libraryRepository.GetAllLibraries();
        }

        public Library GetLibraryById(int id)
        {
            return libraryRepository.GetLibraryById(id);
        }

        public void UpdateLibrary(int id, Library library)
        {
            libraryRepository.UpdateLibrary(id, library);
        }
       public List<BorrowedBooks_LibraryDTO> GetBorrowedBooksCountInLibraries()
        {
            return libraryRepository.GetBorrowedBooksCountInLibraries();
        }
    }
}
