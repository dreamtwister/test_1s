using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Data;
using Books.Controllers;
using Books.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Books.Tests
{
    [TestClass]
    public class CRUDBookTests
    {
        private IBooksManager _manager;

        public CRUDBookTests()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IRepository<Book>>().To<RepositoryMock>();
            kernel.Bind<IImageStorage>().To<StorageMock>();
            kernel.Bind<IBooksManager>().To<BooksManager>();
            kernel.Bind<ICookieManager>().To<CookieManager>();
            kernel.Bind<AuthorsValidator>().ToSelf();
            _manager = kernel.Get<IBooksManager>();
        }

        [TestMethod]
        public void TestAdd()
        {
            var bookVM = new BookViewModel
            {
                Title = "The light pours out of me",
                AuthorsList = { "Peter Merphy" },
                PageCount = 100,
                Publisher = "Records",
                Year = 1900
            };
            var res = _manager.EditBook(bookVM);
            Assert.IsNotNull(res, "Error when add record");
            res = _manager.GetBook(res.BookId);
            Assert.IsNotNull(res, "Added record was not found");
        }

        [TestMethod]
        public void TestEdit()
        {
            var bookViewModel = new BookViewModel
            {
                Title = "Catcher In The Rye",
                AuthorsList = { "Dandy Warhols" },
                PageCount = 1000,
                Publisher = "Records",
                Year = 1910
            };
            var result = _manager.EditBook(bookViewModel);
            result.AuthorsList.Clear();
            result.AuthorsList.Add("Wolf Alice");
            result.Title = "She";
            result.PageCount = 100;
            result.Publisher = "Rec";
            result.Year = 2010;
            var newResult = _manager.EditBook(result);
            Assert.AreNotEqual(bookViewModel.Title, newResult.Title, "Titles are equal");
            Assert.AreNotEqual(bookViewModel.AuthorFirstName, newResult.AuthorFirstName, "FirstNames are equal");
            Assert.AreNotEqual(bookViewModel.AuthorLastName, newResult.AuthorLastName, "LastNames are equal");
            Assert.AreNotEqual(bookViewModel.PageCount, newResult.PageCount, "Pagecount are equal");
            Assert.AreNotEqual(bookViewModel.Publisher, newResult.Publisher, "Publishers are equal");
            Assert.AreNotEqual(bookViewModel.Year, newResult.Year, "Years are equal");
        }

        [TestMethod]
        public void TestDelete()
        {
            var bookVM = new BookViewModel
            {
                Title = "The light pours out of me",
                AuthorsList = { "Peter Merphy" },
                PageCount = 100,
                Publisher = "Records",
                Year = 1900
            };
            var res = _manager.EditBook(bookVM);
            Assert.IsNotNull(res, "Error when add record");
            var delRes = _manager.DeleteBook(res.BookId);
            Assert.IsTrue(delRes, "Delete with error");
            res = _manager.GetBook(res.BookId);
            Assert.IsNull(res, "Returned record was deleted earlier");
        }

        [TestMethod]
        public void TestList()
        {
            var prevCount = _manager.GetBooks().Data.Count;
            var bookVM = new BookViewModel
            {
                Title = "The light pours out of me",
                AuthorsList = { "Peter Merphy" },
                PageCount = 100,
                Publisher = "Records",
                Year = 1900
            };
            _manager.EditBook(bookVM);
            var addCount = _manager.GetBooks().Data.Count;
            Assert.AreEqual(prevCount + 1, addCount, "Data must up by one record greater");
        }
    }
}
