using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class CookieManager: ICookieManager
    {
        private static readonly List<CookieRecord> _cookieDatas = new List<CookieRecord>();

        public void Actualize(string hash)
        {
            var cookieData = _cookieDatas.FirstOrDefault(i => i.HashKey.Equals(hash));
            if (cookieData != null)
                cookieData.IsActual = true;
        }

        public object GetData(string hash, bool active = false)
        {
            var cookieData = _cookieDatas.FirstOrDefault(i => i.HashKey.Equals(hash) && i.IsActual);
            if (cookieData == null) return null;
            cookieData.IsActual = active;
            return cookieData.Data;
        }

        public void AddInfo(string hash, object data)
        {
            var cookieData = _cookieDatas.FirstOrDefault(i => i.HashKey.Equals(hash));
            if (cookieData != null) _cookieDatas.Remove(cookieData);
            _cookieDatas.Add(new CookieRecord
            {
                HashKey = hash,
                Data = data,
                IsActual = false
            });
        }
    }
}
