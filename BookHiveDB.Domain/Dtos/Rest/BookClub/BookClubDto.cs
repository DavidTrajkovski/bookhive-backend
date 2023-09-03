namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class BookClubDto : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Owner { get; set; }
    public int RequestCount { get; set; }
    public bool IsMember { get; set; }
    public bool IsOwner { get; set; }
}
