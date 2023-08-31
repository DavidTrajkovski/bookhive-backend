using System;

namespace BookHiveDB.Domain.Dtos.Rest.Library;

public class EditLastPageReadResponse
{
    public string UserId { get; set; }
    public Guid BookId { get; set; }
    public int LastPageRead { get; set; }
}
