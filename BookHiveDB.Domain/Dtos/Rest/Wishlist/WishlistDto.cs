using System;

namespace BookHiveDB.Domain.Dtos.Rest.Wishlist;

public class WishlistDto
{
    public string UserId { get; set; }
    public Guid BookId { get; set; }
}
