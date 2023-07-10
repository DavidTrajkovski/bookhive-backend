using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.Relations
{
    public class BookInWishList : BaseEntity
    {
        public string UserId { get; set; }
        [JsonIgnore]
        public BookHiveApplicationUser User { get; set; }
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }

    }
}
