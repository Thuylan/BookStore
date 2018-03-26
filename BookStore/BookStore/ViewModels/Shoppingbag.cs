using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class Shoppingbag
    {
        public Customer Customer { get; set; }

        public List<Book> Books { get; set; }
    }
}