using System;
using BookHiveDB.Domain.DTO.REST;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.REST;

public class BookGenreDTO : BaseEntity
{
    public Guid BookId { get; set; }
    public BookDto Book { get; set; }
    public Guid GenreId { get; set; }
    public GenreDTO Genre { get; set; }
}
