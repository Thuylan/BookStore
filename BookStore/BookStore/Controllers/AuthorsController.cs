using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext _context;
        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Author
        public ActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }
    }
}