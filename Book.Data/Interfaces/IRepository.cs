using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public interface IRepository<T> where T : class
    {
        T Add(T item);
        T Edit(T item);
        bool Delete(string itemId);
        IList<T> GetItems();
    }
}
