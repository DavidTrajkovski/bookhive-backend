using System.Collections.Generic;
using BookHiveDB.Domain.DomainModels;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class BookClubInvitations
    {
        public BookClub BookClub { get; set; }
        public List<Invitation> Invitations { get; set; }
        public BookClubInvitations(BookClub bookClub, List<Invitation> invitations)
        {
            this.BookClub = bookClub;
            this.Invitations = invitations;
        }
    }
}
