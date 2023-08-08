using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Domain.Models;

public class Topic : BaseEntity
{
    public string title { get; set; }
    public DateTime date { get; set; }
    public string BookHiveApplicationUserId { get; set; }
    public BookHiveApplicationUser BookHiveApplicationUser { get; set; }
    public Guid BookClubId { get; set; }
    public BookClub BookClub { get; set; }
    public virtual ICollection<Post> PostsBelonging { get; set; }
}
