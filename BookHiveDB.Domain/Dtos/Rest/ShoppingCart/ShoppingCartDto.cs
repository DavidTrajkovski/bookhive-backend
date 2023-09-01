using System.Collections.Generic;
using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Domain.Dtos.Rest.ShoppingCart;

public class ShoppingCartDto : BaseEntity
{
    public string OwnerId { get; set; }
    public BookHiveApplicationUser Owner { get; set; }
    public List<ShoppingCartBookDto> Books { get; set; }
}