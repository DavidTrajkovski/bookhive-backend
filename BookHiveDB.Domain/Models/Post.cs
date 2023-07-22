using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain.DomainModels;

public class Post : BaseEntity
{
    public string content { get; set; }
    public DateTime dateCreated { get; set; }
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    public string BookHiveApplicationUserId { get; set; }
    public BookHiveApplicationUser BookHiveApplicationUser { get; set; }

}