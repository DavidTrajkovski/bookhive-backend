namespace BookHiveDB.Domain.Dtos.Rest.BookClub;

public class InvitationDto : BaseEntity
{
    public string BookClubName { get; set; }
    public string SenderEmail { get; set; }
    public string ReceiverId { get; set; }
    public string Message { get; set; }
    public bool IsRequest { get; set; }
}
