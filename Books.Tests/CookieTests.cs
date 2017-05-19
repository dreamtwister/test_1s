using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Data;
using Books.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Books.Tests
{
    [TestClass]
    public class CookieTests
    {
        private ICookieManager _manager;

        public CookieTests()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICookieManager>().To<CookieManager>();
            _manager = kernel.Get<ICookieManager>();
        }

        [TestMethod]
        public void CheckActulize()
        {
            var hash = Guid.NewGuid().ToString();
            string someData = "someData";
            _manager.AddInfo(hash, someData);
            _manager.Actualize(hash);
            var getData = _manager.GetData(hash) as string;
            Assert.IsNotNull(getData, "Data was not found");
            Assert.AreEqual(getData, someData, "Datas are not equal");
        }

        [TestMethod]
        public void CheckDeactualize()
        {
            var hash = Guid.NewGuid().ToString();
            string someData = "someData";
            _manager.AddInfo(hash, someData);
            _manager.Actualize(hash);
            var getData = _manager.GetData(hash) as string;
            getData = _manager.GetData(hash) as string;
            Assert.IsNull(getData, "Data is not closed");
        }

        [TestMethod]
        public void CheckChange()
        {
            var hash = Guid.NewGuid().ToString();
            string someData = "someData";
            _manager.AddInfo(hash, someData);
            _manager.Actualize(hash);
            var getData1 = _manager.GetData(hash) as string;
            someData = "NotSomeData";
            _manager.AddInfo(hash, someData);
            _manager.Actualize(hash);
            var getData2 = _manager.GetData(hash) as string;
            Assert.AreNotEqual(getData1, getData2, "Data must be changed");
        }
    }
}
