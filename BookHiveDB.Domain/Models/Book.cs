using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Enumerations;

namespace BookHiveDB.Domain.Models;

public class Book : BaseEntity
{
    public string Isbn { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [DataType(DataType.Date)] public DateTime DatePublished { get; set; }
    public string CoverImageUrl { get; set; }
    public double Price { get; set; }
    public int TotalPages { get; set; }
    public bool IsValid { get; set; }
    public virtual ICollection<UserBook> UserBooks { get; set; }
    public virtual List<Author> Authors { get; } = new();
    public virtual ICollection<BookInOrder> BooksInOrders { get; set; }
    public virtual ICollection<BookInShoppingCart> BookInShoppingCarts { get; set; }
    public List<Genre> Genres { get; init; } = new();
    public virtual ICollection<BookInWishList> BookInWishLists { get; set; }
    public virtual List<BookShop> BookShops { get; init; } = new();
}
