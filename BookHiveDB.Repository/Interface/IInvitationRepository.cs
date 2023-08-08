using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Interface
{
    public interface IInvitationRepository
    {
        void Insert(Invitation entity); 
        void Update(Invitation entity); 
        void Delete(Invitation entity); 
        public IEnumerable<Invitation> findAll();  
        public Invitation findById(Guid? invitationId); 
        List<Invitation> findByReceiver(BookHiveApplicationUser receiver); 
        List<Invitation> findByBookClubAndIsRequest(BookClub bookClub, bool isRequest); 
        List<Invitation> findByReceiverAndIsRequest(BookHiveApplicationUser receiver, bool isRequest); 
    }
}
