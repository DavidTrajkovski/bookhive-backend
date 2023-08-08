using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Relations
{
    public class UserInBookClub : BaseEntity
    {
        public Guid BookClubId { get; set; }
        public BookClub BookClub { get; set; }
        public string UserId { get; set; }
        public BookHiveApplicationUser BookHiveApplicationUser { get; set; }

    }
}
