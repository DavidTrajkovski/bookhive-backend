using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IBookClubService
    {
        public List<BookClub> findAll();
        public BookClub findById(Guid bookClubId);
        public List<BookClub> findByMember(string userId);
        public List<BookClub> findAllByNameContainingIgnoreCase(string containing);
        public BookClub save(String name, string ownerId, string description);
        public BookClub edit(Guid bookClubId, string name, string ownerId, string description);
        public void addUserToBookclub(Guid bookClubId, string userId);
        public void removeUserFromBookclub(Guid bookClubId, string userId);
        public void deleteById(Guid bookClubId);
        public List<BookHiveApplicationUser> getAllMembers(BookClub bookClub);
    }
}
