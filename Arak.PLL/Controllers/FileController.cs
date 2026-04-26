using Arak.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpPost("upload-user-photo/{userId}")]
        public async Task<IActionResult> UploadUserPhoto(int userId, IFormFile file)
        {
            var path = await _fileService.UploadFile(file, "users");

            return Ok(path);
        }

        [HttpPost("upload-book")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> UploadBook(IFormFile file)
        {
            var path = await _fileService.UploadFile(file, "books");

            return Ok(path);
        }


        [HttpDelete("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteFile([FromQuery] string filePath)
        {
            var result = await _fileService.DeleteFile(filePath);

            if (!result)
                return NotFound("File not found");

            return Ok("File deleted successfully");
        }
    }
}