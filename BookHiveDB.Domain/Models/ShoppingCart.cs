using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain.DomainModels;

public class ShoppingCart : BaseEntity
{
    public string OwnerId { get; set; }
    public BookHiveApplicationUser Owner { get; set; }
    public virtual ICollection<BookInShoppingCart> BookInShoppingCarts { get; set; }
}
