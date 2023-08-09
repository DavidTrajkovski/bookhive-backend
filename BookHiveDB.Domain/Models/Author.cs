using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;
using BookHiveDB.Domain.DomainModels;

namespace BookHiveDB.Domain.Models;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Biography { get; set; }

    public List<Book> AuthoredBooks { get; init; } = new();
}
