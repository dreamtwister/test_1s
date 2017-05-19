using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class OrderViewModel
    {
        /// <summary>
        /// Наименование поля
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Направление
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Порядок
        /// </summary>
        public int Index { get; set; }
    }

    public enum Order
    {
        NONE = 0,
        ASC,
        DESC
    }
}
