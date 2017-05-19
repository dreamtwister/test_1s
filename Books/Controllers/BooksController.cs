using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books.Core;
using Mvc.JQuery.DataTables;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private IBooksManager _bookManager;
        private ICookieManager _cookieManager;
        private AuthorsValidator _authorsValidator;

        public BooksController(IBooksManager bookManager, ICookieManager cookieManager, AuthorsValidator authorsValidator)
        {
            _bookManager = bookManager;
            _cookieManager = cookieManager;
            _authorsValidator = authorsValidator;
        }

        // GET: Books
        public ActionResult List()
        {
            var cookie = Request.Cookies[0]?.Value;
            _cookieManager.Actualize(cookie);
            return View("List");
        }

        public JsonResult GetBooks(DataTablesParam dataTableParam)
        {
            var cookie = Request.Cookies[0]?.Value;
            var cookieData = _cookieManager.GetData(cookie);
            var data = cookieData as DataTablesParam;
            if (data != null)
            {
                dataTableParam = data;
            }
            else _cookieManager.AddInfo(cookie, dataTableParam);
            var books = _bookManager.GetBooks(DataTableHelper.ToBookList(dataTableParam));
            return Json(new
            {
                iDisplayLength = books.PageSize,
                iDisplayStart = books.ItemStart,
                iTotalDisplayRecords = books.AllItems,
                data?.iSortCol,
                data?.iSortingCols,
                data?.sSortDir,
                data?.bSortable,
                data = books.Data
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(BookViewModel model)
        {
            var result = _authorsValidator.Validate(model.AuthorsList);
            ModelState.AddModelError("Authors", string.Join("/", result.Messages.ToArray()));
            if (!result.Result || !ModelState.IsValid) return PartialView("_Edit", model);
            _bookManager.EditBook(model);
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult GetBook(string id = "")
        {
            Guid guid;
            var model = Guid.TryParse(id, out guid) ? _bookManager.GetBook(id) : new BookViewModel {BookId = Guid.NewGuid().ToString()};
            return PartialView("_Edit", model);
        }

        public JsonResult DeleteBook(string id)
        {
            var model = _bookManager.DeleteBook(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Upload(string id)
        {
            var upload = Request.Files[0];

            if (upload == null) return Json("-");
            var imageArray = upload.FileName.Split('.');
            var extansion = imageArray[imageArray.Length - 1]?.ToLower();
            if (extansion == null ||
                (!extansion.ToUpper().Equals("JPG") 
                && !extansion.ToUpper().Equals("JPEG")
                && !extansion.ToUpper().Equals("PNG") 
                && !extansion.ToUpper().Equals("BMP"))) return Json("-");
            using (var memoryStream = new MemoryStream())
            {
                upload.InputStream.CopyTo(memoryStream);
                var url = _bookManager.UploadFile(id, memoryStream, extansion);
                return Json(url);
            }
        }
    }
}