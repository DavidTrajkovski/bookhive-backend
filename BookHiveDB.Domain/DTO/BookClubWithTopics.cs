using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DTO
{
    public class BookClubWithTopics
    {
        public BookClub BookClub { get; set; }
        public BookHiveApplicationUser user { get; set; }
        public List<Topic> Topics { get; set; }
        public BookClubWithTopics(BookClub bookClub, BookHiveApplicationUser user, List<Topic> topics)
        {
            BookClub = bookClub;
            this.user = user;
            Topics = topics;
        }
    }
}
