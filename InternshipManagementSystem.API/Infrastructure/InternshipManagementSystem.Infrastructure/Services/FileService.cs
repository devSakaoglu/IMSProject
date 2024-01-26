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

                if (first)
                {
                   string oldName = Path.GetFileNameWithoutExtension(fileName);
                   newFileName = $"{NameOperation.CharacterRegulator(oldName)}{extension}";
                }
                else
                {
                   newFileName = fileName;
                   int indexNo1 = newFileName.IndexOf("-");
                   if (indexNo1 == -1)
                   {
                      newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                   }
                   else
                   {
                      int lastIndex = 0;
                      while (true)
                      {
                         lastIndex = indexNo1;
                         indexNo1 = newFileName.IndexOf("-", indexNo1 + 1);
                         if (indexNo1 == -1)
                         {
                            indexNo1 = lastIndex;
                            break;
                         }
                      }

                      int indexNo2 = newFileName.IndexOf(".");
                      string fileNo = newFileName.Substring(indexNo1 + 1, indexNo2 - indexNo1 - 1);
                      if (int.TryParse(fileNo, out int _fileNo))
                      {
                         _fileNo++;
                         newFileName = newFileName.Remove(indexNo1 + 1 , indexNo2 - indexNo1 - 1).Insert(indexNo1 + 1 , _fileNo.ToString());
                      }
                      else
                      {
                         newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                      }    
                   }
                }


                    if (File.Exists($"{path}/{newFileName}"))
                    {
                   return await FileRenameAsync(path, newFileName, false);
                    }
                    else
                    {
                        return newFileName;
                    }

                });
         return newFileName;


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
            var fileNewName = await FileRenameAsync(uploadPath, file.FileName);
            var filePath = $"{uploadPath}\\{fileNewName}";

                bool result = await CopyFileAsync(filePath, file);
            datas.Add((fileNewName, $"{uploadPath}\\{fileNewName}"));
                results.Add(result);
         
                //TODO: exeptioon message return
                //if (result.Equals(false)) any
            //return null;

            }
         if (results.TrueForAll(r => r.Equals(true)))
         {
            return datas;
         }
            return null;
        }
    }
}
