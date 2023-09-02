using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.REST.Author;

namespace BookHiveDB.Domain.Dtos.REST.Book;

public class BookDto : BaseEntity
{
    public string Isbn { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DatePublished { get; set; }
    public string CoverImageUrl { get; set; }
    public string PdfUrl { get; set; }
    public double Price { get; set; }
    public int TotalPages { get; set; }
    public bool IsValid { get; set; }
    public List<string> Genres { get; set; }
    public List<BookAuthorInfoDto> Authors { get; set; }
}
