using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Interface
{
    public interface IBookClubRepository
    {
        public IEnumerable<BookClub> findAll(); 
        public BookClub findById(Guid? bookClubId); 
        public List<BookClub> findBookClubsByMember(string userId);
        public List<BookClub> findAllByNameContainingIgnoreCase(string containing); 
        public void addUserToBookclub(Guid? bookClubId, string userId); 
        public void removeUserToBookclub(Guid? bookClubId, string userId); 
        void Insert(BookClub entity); 
        void Update(BookClub entity); 
        void Delete(BookClub entity); 
    }
}
