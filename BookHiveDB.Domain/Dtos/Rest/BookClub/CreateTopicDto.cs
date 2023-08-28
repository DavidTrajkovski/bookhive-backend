using System;

namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class CreateTopicDto
{
    public string BookclubId { get; set; }
    public string CreatorId { get; set; }
    public string Title { get; set; }
}