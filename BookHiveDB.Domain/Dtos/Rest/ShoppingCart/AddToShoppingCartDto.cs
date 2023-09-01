using System;

namespace BookHiveDB.Domain.Dtos.Rest.ShoppingCart;

public class AddToShoppingCartDto
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
}