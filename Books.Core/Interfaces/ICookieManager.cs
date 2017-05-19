using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public interface ICookieManager
    {
        /// <summary>
        /// Activate data for read
        /// </summary>
        /// <param name="hash"></param>
        void Actualize(string hash);

        /// <summary>
        /// read info for the same cookie
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="data"></param>
        /// <param name="active">false - deactivate data for current cookie</param>
        /// <returns></returns>
        object GetData(string hash, bool active = false);

        /// <summary>
        /// set data to cookie
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="data"></param>
        void AddInfo(string hash, object data);
    }
}
