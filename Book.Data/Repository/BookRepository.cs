using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Books.Data
{
    public class BookRepository : IRepository<Book>
    {
        private string _storagePath;

        public BookRepository(string path = "")
        {
            _storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        /// <summary>
        /// Добавить запись в хранилище
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Book Add(Book item)
        {
            var id = Guid.NewGuid().ToString();
            item.BookId = id;
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText(_storagePath + id + ".json", json);
            var jsonOut = File.ReadAllText(_storagePath + id + ".json");
            item = JsonConvert.DeserializeObject<Book>(jsonOut);
            return item;
        }

        public Book Edit(Book item)
        {
            var id = item.BookId;
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText(_storagePath + id + ".json", json);
            var jsonOut = File.ReadAllText(_storagePath + id + ".json");
            item = JsonConvert.DeserializeObject<Book>(jsonOut);
            return item;
        }

        public bool Delete(string itemId)
        {
            try
            {
                File.Delete(_storagePath + itemId + ".json");
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IList<Book> GetItems()
        {
            var fileNames = Directory.GetFiles(_storagePath, "*.json");
            return fileNames.Select(File.ReadAllText).Select(JsonConvert.DeserializeObject<Book>).ToList();
        }
    }
}
