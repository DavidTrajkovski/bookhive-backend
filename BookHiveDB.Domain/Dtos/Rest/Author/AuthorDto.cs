using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.REST.Author;

public class AuthorDto : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Biography { get; set; }
    public List<BookDto> AuthoredBooks { get; set; }
}
