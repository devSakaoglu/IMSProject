using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files , string StudentID, string InternshipID);

        Task<bool> CopyFileAsync(string sourcePath, IFormFile formFile);

        Task<bool> DeleteFileAsync(string path);

    }

   
}
