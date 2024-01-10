using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        [Route("CreateLibrary")]
        [HttpPost]
        public void CreateLibrary(Library library)
        {
            libraryService.CreateLibrary(library);
        }

        [Route("DeleteLibrary")]
        [HttpDelete]
        public void DeleteLibrary(int id)
        {
            libraryService.DeleteLibrary(id);
        }

        [Route("UpdateLibrary")]
        [HttpPut]
        public void UpdateLibrary(int id, Library library)
        {
            libraryService.UpdateLibrary(id, library);
        }

        [Route("GetAllLibraries")]
        [HttpGet]
        public List<Library> GetAllLibraries()
        {
            return libraryService.GetAllLibraries();
        }

        [Route("GetLibraryById")]
        [HttpGet]
        public Library GetLibraryById(int id)
        {
            return libraryService.GetLibraryById(id);
        }

     
        [Route("uploadImage")]
        [HttpPost]
        public Library UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +
            "_" + file.FileName;
            var fullPath = Path.Combine("D:\\Frond End last 4 Days\\LibrarySystemFrontEnd-1\\src\\assets\\LibraryImages", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Library item = new Library();
            item.Image_Path1 = fileName;
            return item;
        }
        [Route("GetBorrowedBooksCountInLibraries")]
        [HttpGet]
        public List<BorrowedBooks_LibraryDTO> GetBorrowedBooksCountInLibraries()
        {
            return libraryService.GetBorrowedBooksCountInLibraries();
        }
    }
}
