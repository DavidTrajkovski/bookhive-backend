using System;

namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class TopicDto : BaseEntity
{
    public Guid BookclubId { get; set; }
    public string Title { get; set; }
    public string CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
}
