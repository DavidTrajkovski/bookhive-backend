using BookHiveDB.Domain.DomainModels;
using System;

namespace BookHiveDB.Domain.Relations
{
    public class BookGenre : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
