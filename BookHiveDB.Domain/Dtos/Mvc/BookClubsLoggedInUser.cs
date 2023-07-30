using System.Collections.Generic;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class BookClubsLoggedInUser
    {
        public List<BookClub> bookClubs { get; set; }
        public BookHiveApplicationUser user { get; set; }
        public BookClubsLoggedInUser(List<BookClub> bookClubs, BookHiveApplicationUser user)
        {
            this.bookClubs = bookClubs;
            this.user = user;
        }
    }
}
