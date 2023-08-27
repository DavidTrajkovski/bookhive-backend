using System;

namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class CreateNewPostDto
{
    public string Content { get; set; }
    public string UserId { get; set; }
    public Guid TopicId { get; set; }
}
