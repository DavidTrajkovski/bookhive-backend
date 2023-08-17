namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class MemberDto : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
