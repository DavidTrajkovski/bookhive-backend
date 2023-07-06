using BookHiveDB.Domain.DomainModels;
using System;

namespace BookHiveDB.Domain.Relations
{
    public class BookInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
