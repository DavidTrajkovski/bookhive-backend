using BookHiveDB.Domain.DomainModels;
using System;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.Relations
{
    public class BookInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
