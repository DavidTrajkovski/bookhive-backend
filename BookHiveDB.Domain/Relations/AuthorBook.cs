using BookHiveDB.Domain.DomainModels;
using System;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.Relations
{
    public class AuthorBook : BaseEntity
    {
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
    }
}
