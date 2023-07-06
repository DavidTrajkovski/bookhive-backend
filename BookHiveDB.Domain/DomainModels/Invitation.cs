using BookHiveDB.Domain.Identity;
using System;

namespace BookHiveDB.Domain.DomainModels
{
    public class Invitation : BaseEntity
    {
        public Guid BookClubId { get; set; }
        public BookClub BookClub { get; set; } 
        public string UserSenderId { get; set; }
        public BookHiveApplicationUser UserSender { get; set; }
        public string UserReceiverId { get; set; }
        public BookHiveApplicationUser UserReceiver { get; set; }
        public string message { get; set; }
        public bool isRequest { get; set; }
    }
}
