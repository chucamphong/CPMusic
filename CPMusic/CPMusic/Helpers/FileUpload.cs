using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CPMusic.Helpers
{
    public interface IFileUpload
    {
        public Task<string> Save(IFormFile file, string directory);
    }

    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;

        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> Save(IFormFile file, string directory)
        {
            await using Stream stream = file.OpenReadStream();
            using MD5 md5 = MD5.Create();

            // Tạo checksum với MD5 để tránh trường hợp tải lên ảnh bị trùng.
            string fileName = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
            string extension = Path.GetExtension(file.FileName);

            // Nơi lưu tệp tin
            string filePath = Path.Combine(_environment.WebRootPath, directory, $"{fileName}{extension}");

            // Kiểm tra xem tệp tin đã tồn tại hay chưa
            if (!File.Exists(filePath))
            {
                await using FileStream fileSteam = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileSteam);
            }

            // Trả về đường dẫn tương đối để lưu vào cơ sở dữ liệu
            return filePath.Replace(_environment.WebRootPath, string.Empty);
        }
    }
}