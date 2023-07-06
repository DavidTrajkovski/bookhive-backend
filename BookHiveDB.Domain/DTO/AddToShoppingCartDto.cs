using BookHiveDB.Domain.DomainModels;
using System;

namespace BookHiveDB.Domain.DTO
{
    public class AddToShoppingCartDto
    {
            public Book Book { get; set; }
            public Guid BookId { get; set; }
            public int Quantity { get; set; }
    }
}
