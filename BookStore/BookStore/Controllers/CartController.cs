using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Cart
        public List<Cart> GetCart()
        {
            List<Cart> ListProduct = Session["Cart"] as List<Cart>;
            if (ListProduct == null)
            {
                ListProduct = new List<Cart>();
                Session["Cart"] = ListProduct;
            }
            return ListProduct;
        }
        //Add to Cart
        public ActionResult AddToCart(int IdBook , string strUrl)
        {
            Book book = _context.Books.SingleOrDefault(b => b.Id == IdBook);
            if (book == null)
            {
                return HttpNotFound();
            }

            List<Cart> ListProduct = GetCart();
            Cart product = ListProduct.Find(b=>b.IdB==IdBook);
            if (product == null)
            {
                product = new Cart(IdBook);
                return Redirect(strUrl);
            }
            else
            {
                product.Amount++;
                return Redirect(strUrl);
            }
        }

        //Update to Cart
        public ActionResult UpdateCart(int id, FormCollection f)
        {
            Book book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            List<Cart> ListProduct = GetCart();
            Cart product = ListProduct.SingleOrDefault(b => b.IdB == id);
            if (product != null)
            {
                product.Amount = int.Parse(f["amount"].ToString());
            }
            return View("Cart");
        }
        //Delete Cart
        public ActionResult DeleteCart(int id)
        {
            Book book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            List<Cart> ListProduct = GetCart();
            Cart product = ListProduct.SingleOrDefault(b => b.IdB == id);
            if (product != null)
            {
                ListProduct.RemoveAll(c=>c.IdB==id);
            }
            if (ListProduct.Count == 0)
            {
                return RedirectToAction("Index", "Books");
            }
            return RedirectToAction("Cart");
        }
        //
        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Books");
            }
            List<Cart> ListProduct = GetCart();
            return View(ListProduct);
        }
        //Amount
        private int Amount()
        {
            int amount = 0;
            List<Cart> ListProduct = Session["Cart"] as List<Cart>;
            if (ListProduct != null)
            {
                amount = ListProduct.Sum(c => c.Amount);
            }
            return amount;
        }
        private double SumOfPrice()
        {
            double sumOfPrice = 0;
            List<Cart> ListProduct = Session["Cart"] as List<Cart>;
            if (ListProduct != null)
            {
                sumOfPrice = ListProduct.Sum(c => c.Cost);
            }
            return sumOfPrice;
        }

        //Partial Cart
        public ActionResult ParticalCart()
        {
            if (Amount() == 0)
            {
                return PartialView();
            }
            ViewBag.Amount = Amount();
            ViewBag.SumOfPrice = SumOfPrice();
            return PartialView();

        }
    }
}