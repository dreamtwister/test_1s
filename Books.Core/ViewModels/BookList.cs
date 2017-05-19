using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class BookList
    {
        public BookList()
        {
            Orders = new List<OrderViewModel>();
            Data = new List<BookViewModel>();
            PageSize = 10;
        }

        /// <summary>
        /// number of displayed rows
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// First record for show
        /// </summary>
        public int ItemStart { get; set; }

        /// <summary>
        /// Count of all items
        /// </summary>
        public int AllItems { get; set; }

        /// <summary>
        /// Data for table show
        /// </summary>
        public IList<BookViewModel> Data { get; set; }

        /// <summary>
        /// Order list
        /// </summary>
        public List<OrderViewModel> Orders { get; set; }
    }
}
