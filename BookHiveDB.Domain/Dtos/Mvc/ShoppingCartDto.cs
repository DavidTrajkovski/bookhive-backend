using System.Collections.Generic;
using BookHiveDB.Domain.Relations;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class ShoppingCartDto
    {
        public List<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
