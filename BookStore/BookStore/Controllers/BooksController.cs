using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {

        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var books = _context.Books.Include(m => m.Genre).Include(m => m.Author).ToList();
            if (User.IsInRole("Admin"))
            {
                return View("Index", books);
            }
            else

            return View("IndexforCustomer",books);
        }
        public ActionResult New()
        {
            var Genre = _context.Genres.ToList();
            var Author = _context.Authors.ToList();
            var Book = new BookFormViewModel
            {
                Book = new Book(),
                Authors = Author,
                Genres = Genre
            };
            return View("BookForm",Book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var BookView = new BookFormViewModel()
                {
                    Book = book,
                    Authors = _context.Authors.ToList(),
                    Genres = _context.Genres.ToList()
                };
                return View("BookForm", BookView);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }

            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.ImgUrl = book.ImgUrl;
                bookInDb.Name = book.Name;
                bookInDb.Publisher = book.Publisher;
                bookInDb.Price = book.Price;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.ContentSummary = book.ContentSummary;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.GenreId = book.GenreId;
                bookInDb.AuthorId = book.AuthorId;
                

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var Book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            var BookView = new BookFormViewModel
            {
                Book = Book,
                Authors = _context.Authors.ToList(),
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", BookView);
        }
        public ActionResult Detail(int id)
        {
            var book = _context.Books.Include(m => m.Genre).Include(m => m.Author).SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult ThieuNhi()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m=>m.Genre)
                        where b.GenreId==2
                        select b;
            return View(books);
        }
        public ActionResult Vanhoc()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m => m.Genre)
                        where b.GenreId == 1
                        select b;
            return View(books);
        }
        public ActionResult ThuongthucDS()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m => m.Genre)
                        where b.GenreId == 3
                        select b;
            return View("Vanhoc",books);
        }
        public ActionResult NXBHaNoi()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m => m.Genre)
                        where b.Publisher == "NXB Hà Nội"
                        select b;
            return View("Publisher",books);
        }
        public ActionResult NXBVanhoc()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m => m.Genre)
                        where b.Publisher == "NXB Văn học"
                        select b;
            return View("Publisher", books);
        }
        public ActionResult NXBNhaNam()
        {
            var books = from b in _context.Books.Include(m => m.Author).Include(m => m.Genre)
                        where b.Publisher == "NXB Nhã Nam"
                        select b;
            return View("Publisher", books);
        }
    }
}