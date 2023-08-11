namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class BookClubDto : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Owner { get; set; }
}
