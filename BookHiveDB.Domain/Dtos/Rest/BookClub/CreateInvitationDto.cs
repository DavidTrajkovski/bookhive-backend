using System;

namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class CreateInvitationDto
{
    public Guid BookClubId { get; set; }
    public string SenderId { get; set; }
    public string ReceiverEmail { get; set; }
    public string Message { get; set; }
}
