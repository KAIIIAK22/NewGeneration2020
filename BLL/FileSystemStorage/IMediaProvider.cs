using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FileSystemStorage
{
    public interface IMediaProvider
    {
        bool Upload(byte[] dateBytes, string path);

        byte[] Read(string path);

        bool Delete(string path);
    }
}
