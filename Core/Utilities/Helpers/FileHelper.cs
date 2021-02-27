using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file, string filePath)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file, filePath);
            File.Move(sourcepath, result);
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file, string filePath)
        {
            var result = newPath(file, filePath);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file,string filePath)
        {
            FileInfo FileInfo = new FileInfo(file.FileName);
            string fileExtension = FileInfo.Extension;

            string path = Environment.CurrentDirectory + $@"\wwwroot\Images\{filePath}";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
