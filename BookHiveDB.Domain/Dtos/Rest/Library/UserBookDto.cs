using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.Rest.Library;

public class UserBookDto
{
    public string UserId { get; set; }
    public BookDto Book { get; set; }
    public int LastPageRead { get; set; }
}
