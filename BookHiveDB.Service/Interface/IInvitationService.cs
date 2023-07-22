using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Service.Interface
{
    public interface IInvitationService
    {
        Invitation findById(Guid invitationId);
        List<Invitation> findByReceiver(string receiverEmail);
        List<Invitation> findByBookClubAndIsRequest(Guid bookClubId, bool isRequest);
        List<Invitation> findByReceiverAndIsRequest(string receiverId, bool isRequest);
        Invitation save(string senderId, string receiverEmail, Guid bookClubId, string message, bool isRequest);
        void deleteById(Guid invitationId);
    }
}
