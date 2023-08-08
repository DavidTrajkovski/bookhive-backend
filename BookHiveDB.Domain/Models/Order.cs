using System.Collections.Generic;
using System.Text.Json.Serialization;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;

namespace BookHiveDB.Domain.Models;

public class Order : BaseEntity
{
    public string UserId { get; set; }
    public BookHiveApplicationUser User { get; set; }

    [JsonIgnore]
    public virtual ICollection<BookInOrder> BooksInOrders { get; set; }
}
