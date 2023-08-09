using System;
using System.Collections.Generic;

namespace BookHiveDB.Domain.Dtos.Rest.BookShop;

public class AddBooksToBookShopDto
{
    public Guid BookShopId { get; set; }
    public List<Guid> BookIds { get; set; }
}
