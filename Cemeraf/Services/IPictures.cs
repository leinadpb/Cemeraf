using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.Services
{
    public interface IPictures
    {
        Task<string> UploadPictureToS3(string pathToFile, string extension);
    }
}
