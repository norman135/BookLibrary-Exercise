using BookLibrary.Contexts;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BooklibraryContext _context;

        public LibraryController()
        {
            _context = new BooklibraryContext();
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(_context.Books.ToList());
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