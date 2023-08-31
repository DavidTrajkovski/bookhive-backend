using System;
using System.Collections.Generic;

namespace BookHiveDB.Domain.Dtos.REST.Book;

public class CreateBookDto
{
    public string Isbn { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DatePublished { get; set; }
    public string CoverImageUrl { get; set; }
    public double Price { get; set; }
    public int TotalPages { get; set; }
    public string[] Genres { get; set; } 
    public IEnumerable<Guid> AuthorIds { get; set; }
}
