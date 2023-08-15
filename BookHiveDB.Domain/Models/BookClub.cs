using System.Collections.Generic;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;

namespace BookHiveDB.Domain.Models;

public class BookClub : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public string BookHiveApplicationUserId { get; set; }
    public BookHiveApplicationUser BookHiveApplicationUser { get; set; }
    public List<UserInBookClub> UserInBookClubs { get; init; } = new();
    public List<Topic> Topics { get; init; } = new();

    public List<Invitation> Invitations { get; init; } = new();

    public bool isMember(BookHiveApplicationUser user)
    {
        foreach (UserInBookClub userClub in UserInBookClubs)
        {
            if (userClub.UserId.Equals(user.Id))
            {
                return true;    
            }
        }
        return false;
    }

}
