using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DTO.REST;

public class ShoppingCartDTO : BaseEntity
{
    public string OwnerId { get; set; }
    public BookHiveApplicationUserDTO Owner { get; set; }
    public virtual ICollection<BookInShoppingCartDTO> BookInShoppingCarts { get; set; }
}