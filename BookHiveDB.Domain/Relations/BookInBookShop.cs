using BookHiveDB.Domain.DomainModels;
using System;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.Relations
{
    public class BookInBookShop : BaseEntity
    {
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        public Guid BookShopId { get; set; }
        [JsonIgnore]
        public BookShop BookShop { get; set; }
    }
}
