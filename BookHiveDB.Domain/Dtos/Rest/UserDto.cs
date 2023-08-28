namespace BookHiveDB.Domain.Dtos.Rest;

public class UserDto : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}