using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BookHiveDB.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public BookHiveApplicationUser User { get; set; }

        [JsonIgnore]
        public virtual ICollection<BookInOrder> BooksInOrders { get; set; }
    }
}
