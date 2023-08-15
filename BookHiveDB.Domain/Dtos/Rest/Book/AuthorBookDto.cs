using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.REST.Author;

namespace BookHiveDB.Domain.Dtos.REST.Book;

public class AuthorBookDto : BaseEntity
{
    public string bookName { get; set; }
}
