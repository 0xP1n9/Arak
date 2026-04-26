using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file, string folderName);
        Task<bool> DeleteFile(string filePath);
    }
}
