using BookHiveDB.Domain.Relations;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
