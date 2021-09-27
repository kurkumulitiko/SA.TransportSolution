using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using SA.Transport.Core.Application.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SA.Transport.Infrastructure.Files
{
    public class FileManager : IFileManager
    {
        private readonly string address;

        public FileManager(string address)
        {
            this.address = address;
        }


        /// <summary>
        /// ინახავს ფაილს მითითებული სახელით
        /// </summary>
        /// <param name="file">ფაილი</param>
        /// <param name="fileName">ფაილის ახალი სახელი</param>
        public void SaveFile(IFormFile file, string fileName)
        {

            Directory.CreateDirectory(address);

            var filePath = Path.Combine(address, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

        }

        /// <summary>
        /// შლის ფაილს მითითებული სახელით
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            var target = Path.Combine(address, fileName);
            if (Directory.Exists(target))
            {
                var filePath = Path.Combine(target, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }


    }
}
