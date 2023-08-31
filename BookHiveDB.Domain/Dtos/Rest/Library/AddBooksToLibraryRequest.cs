using System;
using System.Collections.Generic;

namespace BookHiveDB.Domain.Dtos.Rest.Library;

public class AddBooksToLibraryRequest
{
    public List<Guid> BookIds { get; set; }
}
