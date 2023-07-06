using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;

namespace BookHiveDB.Domain.Relations
{
    public class BookInWishList : BaseEntity
    {
        public string UserId { get; set; }
        public BookHiveApplicationUser User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }

    }
}
