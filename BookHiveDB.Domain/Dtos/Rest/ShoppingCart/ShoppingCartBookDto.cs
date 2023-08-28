using System;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.Rest.ShoppingCart;

public class ShoppingCartBookDto : BaseEntity
{
    public BookDto Book { get; set; }
    public ShoppingCartDto ShoppingCart { get; set; }
    public int Quantity { get; set; }
}