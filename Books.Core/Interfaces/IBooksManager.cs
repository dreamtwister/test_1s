using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public interface IBooksManager
    {
        /// <summary>
        /// Get record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BookViewModel GetBook(string id);
        /// <summary>
        /// Edit book record
        /// </summary>
        /// <param name="bookViewModel"></param>
        /// <returns></returns>
        BookViewModel EditBook(BookViewModel bookViewModel);
        /// <summary>
        /// Get kist of books
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        BookList GetBooks(BookList list = null);
        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteBook(string id);

        /// <summary>
        /// Load image for book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        string UploadFile(string id, MemoryStream file, string extension);
    }
}
