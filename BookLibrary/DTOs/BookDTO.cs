using BookLibrary.Models;

namespace BookLibrary.DTOs
{
    public class BookDTO(Book book, Author author)
    {
        public string? Title { get; set; } = book.Title;
        public AuthorDTO? Author { get; set; } = new AuthorDTO(author);
    }
}
