using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookStore.Dtos;
using BookStore.Models;

namespace BookStore.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/books
        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books.ToList().Select(Mapper.Map<Book, BookDto>);
        }
        //Get /api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return Ok(Mapper.Map<Book,BookDto>(book));
        }
        //Post /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri+"/"+book.Id),bookDto);
        }
        //Put /api/books/1
        [HttpPut]
        public void UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(bookDto, bookInDb);

            _context.SaveChanges();
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
                return NotFound();
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
