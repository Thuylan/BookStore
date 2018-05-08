using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public int IdB { get; set;}
        public string NameOfBook { get; set; }
        public string Picture { get; set; }
        public double Cost { get; set; }
        public int Amount { get; set; }
        public double SumPrice
        {
            get { return Amount * Cost; }
        }

        public Cart(int IdBook)
        {
            IdB = IdBook;
            Book book = db.Books.Single(b => b.Id == IdB);
            NameOfBook = book.Name;
            Picture = book.ImgUrl;
            Cost = double.Parse(book.Price.ToString());
            Amount = 1;
        }
    }
}