using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class AuthorModels
    {
        public Author author { get; set; }
        public IEnumerable<Book> books { get; set; }
    }
}