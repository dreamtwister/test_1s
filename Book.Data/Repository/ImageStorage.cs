using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class ImageStorage : IImageStorage
    {
        private string _storagePath;
        private string _fullPath;

        public ImageStorage(string path = "")
        {
            _storagePath = path;
            _fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        public string SaveImage(string id, MemoryStream file, string extension)
        {
            var url = _storagePath + id + "." + extension;
            var storage = _fullPath + id + "." + extension;
            try
            {
                using (var fileStream = new FileStream(storage, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    file.Position = 0;
                    file.CopyTo(fileStream);
                }
                return url;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
