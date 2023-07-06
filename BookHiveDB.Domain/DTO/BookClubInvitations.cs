using BookHiveDB.Domain.DomainModels;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DTO
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
