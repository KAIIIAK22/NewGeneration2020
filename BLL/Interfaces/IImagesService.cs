using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImagesService
    {
        Task<bool> UploadTempImageAsync(byte[] dateBytes, string path, UserDto userDto);
        Task<bool> UploadImageAsync(byte[] dateBytes, string path, UserDto userDto);

        byte[] ReadFile(string path);

        Task<bool> DeleteFileAsync(string path);

        string NameCleaner(string fileName);
    }
}
