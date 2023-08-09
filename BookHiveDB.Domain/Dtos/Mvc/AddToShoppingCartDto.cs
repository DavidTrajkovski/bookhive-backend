using System;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class AddToShoppingCartDto
    {
            public Book Book { get; set; }
            public Guid BookId { get; set; }
            public int Quantity { get; set; }
    }
}
