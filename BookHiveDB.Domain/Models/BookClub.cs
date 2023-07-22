using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DomainModels;

public class BookClub : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public string BookHiveApplicationUserId { get; set; }
    public BookHiveApplicationUser BookHiveApplicationUser { get; set; }
    public virtual ICollection<UserInBookClub> UserInBookClubs { get; set; }
    public virtual ICollection<Topic> Topics { get; set; }

    public virtual ICollection<Invitation> Invitations { get; set; }

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