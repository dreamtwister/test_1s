using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Data;

namespace Books.Core
{
    public class BooksManager : IBooksManager
    {
        private IRepository<Book> _repository;
        private IImageStorage _imageStorage;

        private Func<List<string>, string> _toCommaString = delegate(List<string> stringList)
        {
            if (!stringList.Any()) return string.Empty;
            var res = stringList.FirstOrDefault();
            stringList.RemoveAt(0);
            return stringList.Aggregate(res, (current, str) => current + (", " + str));
        };

        public BooksManager(IRepository<Data.Book> repository, IImageStorage imageStorage)
        {
            _repository = repository;
            _imageStorage = imageStorage;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember("AuthorLastName", opt => opt.MapFrom(c => c.Authors.FirstOrDefault().LastName))
                    .ForMember("AuthorFirstName", opt => opt.MapFrom(c => c.Authors.FirstOrDefault().FirstName))
                    .ForMember("Authors", opt => opt.MapFrom( c => _toCommaString( c.Authors.Select(i=>i.LastName + " " + i.FirstName).ToList())))
                    .ForMember("AuthorsList", opt => opt.Ignore());
                cfg.CreateMap<BookViewModel, Book>()
                    .ForMember("Authors", opt => opt.Ignore());
            }
            );
        }

        public BookViewModel GetBook(string id)
        {
            var book = _repository.GetItems().FirstOrDefault(i => i.BookId == id);
            var bookViewModel = Mapper.Map<Book, BookViewModel>(book);
            if (bookViewModel == null) return null;
            if (book == null) return bookViewModel;
            foreach (var t in book.Authors)
                bookViewModel.AuthorsList.Add(t.LastName + " " + t.FirstName);
            return bookViewModel;
        }

        public BookViewModel EditBook(BookViewModel bookViewModel)
        {
            if (bookViewModel == null) return null;
            var authors = bookViewModel.AuthorsList.Select(author => author.Trim().Split()).Select(splitAuthor => new Author
            {
                FirstName = splitAuthor[0], LastName = splitAuthor[1]
            }).ToList();

            var book = string.IsNullOrWhiteSpace(bookViewModel.BookId) ? null : _repository.GetItems().FirstOrDefault(i => i.BookId == bookViewModel.BookId);
            if (book != null)
            {
                book = Mapper.Map<BookViewModel, Book>(bookViewModel);
                book.Authors.AddRange(authors);
                _repository.Edit(book);
            }
            else
            {
                book = Mapper.Map<BookViewModel, Book>(bookViewModel);
                book.Authors.AddRange(authors);
                book = _repository.Add(book);
            }
            return GetBook(book.BookId);
        }

        public bool DeleteBook(string id)
        {
            return _repository.Delete(id);
        }

        public string UploadFile(string id, MemoryStream file, string extension)
        {
            var url = _imageStorage.SaveImage(id, file, extension);
            if (string.IsNullOrWhiteSpace(url)) return string.Empty;
            var book = _repository.GetItems().FirstOrDefault(i => i.BookId == id);
            if (book == null) return url;
            book.BookImageUrl = url;
            _repository.Edit(book);
            return url;
        }

        public BookList GetBooks(BookList list = null)
        {
            list = list ?? new BookList();
            var data = _repository.GetItems().ToList();
            list.AllItems = data.Count;
            foreach (var sort in list.Orders.OrderBy(i=>i.Index))
            {
                switch (sort.Key)
                {
                    case "Title":
                        if (sort.Order == Order.ASC) data = data.OrderBy(i => i.Title).ToList();
                        if (sort.Order == Order.DESC) data = data.OrderByDescending(i => i.Title).ToList();
                        break;
                    case "Year":
                        if (sort.Order == Order.ASC) data = data.OrderBy(i => i.Year).ToList();
                        if (sort.Order == Order.DESC) data = data.OrderByDescending(i => i.Year).ToList();
                        break;
                }
            }
            data = data.Skip(list.ItemStart).Take(list.PageSize).ToList();
            list.Data = Mapper.Map<List<Book>, List<BookViewModel>>(data);
            return list;
        }
    }
}
