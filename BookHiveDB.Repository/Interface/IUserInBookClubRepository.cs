using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Repository.Interface
{
    public interface IUserInBookClubRepository
    {
        IEnumerable<UserInBookClub> GetAll();
        UserInBookClub Get(Guid? id);
        void Insert(UserInBookClub entity);
        void Update(UserInBookClub entity);
        void Delete(UserInBookClub entity);
        public List<UserInBookClub> findByMember(string userId);
        public List<UserInBookClub> findByBookClub(BookClub bookClub);
        public void addUserInBookclub(BookClub bookClub, BookHiveApplicationUser user);
        public void removeUserInBookclub(BookClub bookClub, BookHiveApplicationUser user);
    }
}
