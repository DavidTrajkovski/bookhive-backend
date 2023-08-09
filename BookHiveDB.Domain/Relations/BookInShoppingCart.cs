using BookHiveDB.Domain.DomainModels;
using System;
using System.Text.Json.Serialization;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Relations
{
    public class BookInShoppingCart : BaseEntity
    {
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        public Guid ShoppingCartId { get; set; }
        [JsonIgnore]
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
