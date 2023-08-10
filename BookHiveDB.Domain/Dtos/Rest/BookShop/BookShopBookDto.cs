using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Domain.Dtos.Rest.BookShop;

public class BookShopBookDto : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public List<BookAuthorInfoDto> Authors { get; set; }
}
