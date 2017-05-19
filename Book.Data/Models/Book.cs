using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        /// <summary>
        /// идентификатор книги
        /// </summary>
        public string BookId { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Авторы книги
        /// </summary>
        public List<Author> Authors { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Изображение книги
        /// </summary>
        public string BookImageUrl { get; set; }
    }
}
