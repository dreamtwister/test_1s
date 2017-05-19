using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class CookieRecord
    {
        /// <summary>
        /// Сам хэш
        /// </summary>
        public string HashKey { get; set; }

        /// <summary>
        /// Данные для сохранения
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Стоит ли их брать?
        /// </summary>
        public bool IsActual { get; set; }
    }
}
