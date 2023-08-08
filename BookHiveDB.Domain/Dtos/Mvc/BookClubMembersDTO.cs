using System.Collections.Generic;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class BookClubMembersDTO
    {
        public BookHiveApplicationUser user { get; set; }
        public List<BookHiveApplicationUser> members { get; set; }
        public BookClub bookClub { get; set; }

        public BookClubMembersDTO(BookHiveApplicationUser user, BookClub bookClub, List<BookHiveApplicationUser> members)
        {
            this.user = user;
            this.members = members;
            this.bookClub = bookClub;
        }
    }
}
