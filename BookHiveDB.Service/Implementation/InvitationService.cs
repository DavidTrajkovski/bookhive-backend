using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Implementation
{
    public class InvitationService : IInvitationService
    {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;
        private readonly IInvitationRepository invitationRepository;

        public InvitationService(IUserRepository userRepository, IInvitationRepository invitationRepository, IBookClubRepository bookClubRepository)
        {
            this.userRepository = userRepository;
            this.invitationRepository = invitationRepository;
            this.bookClubRepository = bookClubRepository;
        }

        public bool membershipRequestExists(string senderId, Guid bookClubId, bool isRequest)
        {
            BookHiveApplicationUser sender = userRepository.Get(senderId);
            BookClub bookClub = bookClubRepository.findById(bookClubId);

            return invitationRepository.membershipRequestExists(sender, bookClub, isRequest);
        }

        public void deleteById(Guid invitationId)
        {
            Invitation invitation = findById(invitationId);
            invitationRepository.Delete(invitation);
        }

        public List<Invitation> findByBookClubAndIsRequest(Guid bookClubId, bool isRequest)
        {
            BookClub bookClub = bookClubRepository.findById(bookClubId);
            return invitationRepository.findByBookClubAndIsRequest(bookClub, isRequest).ToList();
        }

        public Invitation findById(Guid invitationId)
        {
            return invitationRepository.findById(invitationId);
        }

        public List<Invitation> findByReceiver(string receiverEmail)
        {
            BookHiveApplicationUser receiver = userRepository.FindByEmail(receiverEmail);
            return invitationRepository.findByReceiver(receiver).ToList();
        }
        public List<Invitation> findByReceiverAndIsRequest(string receiverId, bool isRequest)
        {
            BookHiveApplicationUser receiver = userRepository.Get(receiverId);
            return invitationRepository.findByReceiverAndIsRequest(receiver, isRequest).ToList();
        }

        public Invitation save(string senderId, string receiverEmail, Guid bookClubId, string message, bool isRequest)
        {
            if (membershipRequestExists(senderId, bookClubId, true)) return new Invitation();
            
            BookHiveApplicationUser sender = userRepository.Get(senderId);
            BookHiveApplicationUser receiver = userRepository.FindByEmail(receiverEmail);
            BookClub bookClub = bookClubRepository.findById(bookClubId);
            Invitation invitation = new Invitation { BookClub = bookClub, BookClubId = bookClubId, IsRequest = isRequest, Message = message, UserReceiver = receiver, UserReceiverId = receiver.Id, UserSender = sender, UserSenderId = senderId };
            invitationRepository.Insert(invitation);
            return invitation;
        }
    }
}
