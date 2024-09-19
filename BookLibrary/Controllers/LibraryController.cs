using BookLibrary.Contexts;
using BookLibrary.DTOs;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BooklibraryContext _context;

        public LibraryController(BooklibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetBooks()
        {

            var books = _context.Books.Include(b => b.Author).Select(book => new BookDTO(book, book.Author));

            return Ok(books);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Created("", book);
        }
    }
}