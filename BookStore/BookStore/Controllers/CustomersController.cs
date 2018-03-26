using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customer = new Customer() { Name = "John Smith" };

            var books = new List<Book>
            {
                new Book{ Name="Tiếng gọi nơi hoang dã"},
                new Book{Name ="Không gia đình"},
                new Book{Name ="Tắt đèn"}
            };

            var viewModel = new Shoppingbag()
            {
                Customer = customer,
                Books = books
            };
            return View(viewModel);
        }
    }
}