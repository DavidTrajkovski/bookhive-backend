using BookHiveDB.Domain.DomainModels;
using System;

namespace BookHiveDB.Domain.Relations
{
    public class AuthorBook : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
