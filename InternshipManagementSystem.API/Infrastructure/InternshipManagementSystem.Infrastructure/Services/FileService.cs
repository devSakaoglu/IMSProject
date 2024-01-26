using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Infrastructure.StaticServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InternshipManagementSystem.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string sourcePath, IFormFile formFile)
        {
            try
            {
                await using var fileStream = new FileStream(sourcePath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                throw ex;
            }
        }

        private async Task<string> FileRenameAsync(string path, string fileName, bool first = true)
        {
            string newFileName = await Task.Run<string>(async () =>
                {

                    string extension = Path.GetExtension(fileName);
                    string oldname = Path.GetFileNameWithoutExtension(fileName);
                    string newFileName = $"{NameOperation.CharacterRegulator(oldname)}{extension}";

                    if (File.Exists($"{path}/{newFileName}"))
                    {
                        return await FileRenameAsync(path, $"{Path.GetFileNameWithoutExtension(newFileName)}", false);
                    }
                    else
                    {
                        return newFileName;
                    }

                });
            return "";


        }



        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();

            foreach (IFormFile file in files)
            {
                var fileNewName = await FileRenameAsync(path,file.FileName);
                var filePath = $"{uploadPath}/{fileNewName}";

                bool result = await CopyFileAsync(filePath, file);
                datas.Add((fileNewName, $"{uploadPath}/{fileNewName}"));
                results.Add(result);
                if (results.TrueForAll(r => result.Equals(true)))
                {
                    return datas;
                }
                //TODO: exeptioon message return
                //if (result.Equals(false)) any
                return null;

            }
            return null;
        }
    }
}
