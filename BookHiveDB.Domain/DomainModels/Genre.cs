using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain.DomainModels
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
