using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Data;

namespace Books.Tests
{
    public class RepositoryMock : IRepository<Book>
    {
        private List<Book> _books;

        public RepositoryMock()
        {
            _books = new List<Book>();
        }

        public Book Add(Book item)
        {
            item.BookId = Guid.NewGuid().ToString();
            _books.Add(item);
            var newBook = _books.FirstOrDefault(i => i.BookId == item.BookId);
            return newBook;
        }

        public Book Edit(Book item)
        {
            if (item == null) return null;
            var editBook = _books.FirstOrDefault(i => i.BookId == item.BookId);
            _books.Remove(editBook);
            _books.Add(item);
            return _books.FirstOrDefault(i => i.BookId == item.BookId);
        }

        public bool Delete(string itemId)
        {
            var delBook = _books.FirstOrDefault(i => i.BookId == itemId);
            if (delBook == null) return false;
            _books.Remove(delBook);
            delBook = _books.FirstOrDefault(i => i.BookId == itemId);
            return delBook == null;
        }

        public IList<Book> GetItems()
        {
            return _books;
        }
    }
}
