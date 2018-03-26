using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            var book = new Book { Name = "Tiếng gọi nơi hoang dã" };
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            if (id == 1)
                return Content("id = " + id);
            else
                return RedirectToAction("Index", "Books");
            
        }
        public ActionResult Detail()
        {
            return RedirectToAction("Index","Books");
        }
    }
}