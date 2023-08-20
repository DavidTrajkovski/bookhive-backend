using System;
using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Domain.Models;

public class Invitation : BaseEntity
{
    public Guid BookClubId { get; set; }
    public BookClub BookClub { get; set; } 
    public string UserSenderId { get; set; }
    public BookHiveApplicationUser UserSender { get; set; }
    public string UserReceiverId { get; set; }
    public BookHiveApplicationUser UserReceiver { get; set; }
    public string Message { get; set; }
    public bool IsRequest { get; set; }
}
