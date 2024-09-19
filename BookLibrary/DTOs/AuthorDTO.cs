using BookLibrary.Models;

namespace BookLibrary.DTOs
{
    public class AuthorDTO(Author author)
    {
        public string? FirstName { get; set; } = author.FirstName;
        public string? LastName { get; set; } = author.LastName;
    }
}
