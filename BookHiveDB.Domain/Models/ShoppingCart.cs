using System.Collections.Generic;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;

namespace BookHiveDB.Domain.Models;

public class ShoppingCart : BaseEntity
{
    public string OwnerId { get; set; }
    public BookHiveApplicationUser Owner { get; set; }
    public virtual ICollection<BookInShoppingCart> BookInShoppingCarts { get; set; }
}
