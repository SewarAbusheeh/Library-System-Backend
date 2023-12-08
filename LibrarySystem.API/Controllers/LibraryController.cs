using LibrarySystem.Core.Data;
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
    }
}
