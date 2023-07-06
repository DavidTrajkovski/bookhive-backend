using BookHiveDB.Domain.DomainModels;
using System;

namespace BookHiveDB.Domain.Relations
{
    public class BookInBookShop : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid BookShopId { get; set; }
        public BookShop BookShop { get; set; }
    }
}
