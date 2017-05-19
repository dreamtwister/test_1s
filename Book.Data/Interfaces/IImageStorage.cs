using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public interface IImageStorage
    {
        string SaveImage(string id, MemoryStream file, string extension);
    }
}
