using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Core.Application.Interfaces
{
    public interface IFileManager
    {
        void SaveFile(IFormFile file, string fileName);
        void DeleteFile(string subDirectory);
    }
}
