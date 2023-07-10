using BookHiveDB.Domain.DomainModels;
using System;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.Relations
{
    public class BookGenre : BaseEntity
    {
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        public Guid GenreId { get; set; }
        [JsonIgnore]
        public Genre Genre { get; set; }

    }
}
