using LibrarySystem.Core.Data;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void CreateLibrary(Library library)
        {
            libraryService.CreateLibrary(library);
        }

        [Route("DeleteLibrary")]
        [HttpDelete]
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public void DeleteLibrary(int id)
        {
            libraryService.DeleteLibrary(id);
        }

        [Route("UpdateLibrary")]
        [HttpPut]
        [Authorize]
        [RequiresClaim("roleid", "1")]
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
        [Authorize]
        [RequiresClaim("roleid", "1")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            if (file != null && (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png"))
            {
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("C:\\Users\\Amir Herzallah\\Desktop\\Tahaluf Internship\\01_Projects\\Final Project\\Angular\\LibrarySystem\\src\\assets\\images", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Library item = new Library();
                item.Image_Path1 = fileName;
                return Ok(item);
            }
            else
            {
                return BadRequest("Invalid file format. Please upload an image file.");
            }
        }

        [Route("GetBorrowedBooksCountInLibraries")]
        [HttpGet]
        public List<BorrowedBooks_LibraryDTO> GetBorrowedBooksCountInLibraries()
        {
            return libraryService.GetBorrowedBooksCountInLibraries();
        }

    }
}
