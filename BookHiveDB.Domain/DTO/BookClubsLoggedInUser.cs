using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DTO
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
