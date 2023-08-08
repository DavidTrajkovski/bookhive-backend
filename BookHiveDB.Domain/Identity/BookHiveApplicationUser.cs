using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Relations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Identity
{
    public class BookHiveApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserBook> userBooks { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
        public virtual ICollection<BookInWishList> BookInWishLists { get; set; }
        public virtual ICollection<UserInBookClub> UserInBookClubs { get; set; }
        public virtual ICollection<BookClub> BookClubsOwned { get; set; }
        public virtual ICollection<Topic> TopicsCreated { get; set; }
        public virtual ICollection<Invitation> InvitationsSent { get; set; }
        public virtual ICollection<Invitation> InvitationsReceived { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
