namespace BookHiveDB.Domain.Dtos.REST.Author;

public class CreateAuthorDto : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Biography { get; set; }
}
