using System;

namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class PostDto : BaseEntity
{
    public Guid TopicId { get; set; }
    public Guid CreatorId { get; set; }
    public string Creator { get; set; }
    public DateTime DateCreated { get; set; }
    public string Content { get; set; }
}
