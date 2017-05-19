using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Data;

namespace Books.Tests
{
    public class StorageMock : IImageStorage
    {
        public string SaveImage(string id, MemoryStream file, string extension)
        {
            return id + "." + extension;
        }
    }
}
