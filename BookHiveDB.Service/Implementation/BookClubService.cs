using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Service.Implementation
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository bookClubRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserInBookClubRepository userInBookClubRepository;

        public BookClubService(IBookClubRepository bookClubRepository, IUserRepository userRepository, IUserInBookClubRepository userInBookClubRepository)
        {
            this.bookClubRepository = bookClubRepository;
            this.userRepository = userRepository;
            this.userInBookClubRepository = userInBookClubRepository;
        }

        public BookClub findById(Guid bookClubId)
        {
            return bookClubRepository.findById(bookClubId);
        }

        public List<BookClub> findAll()
        {
            return bookClubRepository.findAll().ToList();
        }

        public List<BookClub> findAllByNameContainingIgnoreCase(string containing)
        {
            return bookClubRepository.findAllByNameContainingIgnoreCase(containing);
        }

        public List<BookClub> findByMember(string userId)
        {
            return bookClubRepository.findBookClubsByMember(userId);
        }

        public void addUserToBookclub(Guid bookClubId, string userId)
        {
            BookClub bookClub = bookClubRepository.findById(bookClubId);
            BookHiveApplicationUser user = userRepository.Get(userId);
            userInBookClubRepository.addUserInBookclub(bookClub, user);
        }

        public void removeUserFromBookclub(Guid bookClubId, string userId)
        {
            BookClub bookClub = bookClubRepository.findById(bookClubId);
            BookHiveApplicationUser user = userRepository.Get(userId);
            userInBookClubRepository.removeUserInBookclub(bookClub, user);
        }

        public void deleteById(Guid bookClubId)
        {
            BookClub BookClub = bookClubRepository.findById(bookClubId);
            bookClubRepository.Delete(BookClub);
        }

        public BookClub edit(Guid bookClubId, string name, string ownerId, string description)
        {
            BookClub BookClub = bookClubRepository.findById(bookClubId);
            BookHiveApplicationUser owner = userRepository.Get(ownerId);
            BookClub.name = name;
            BookClub.description = description;
            BookClub.BookHiveApplicationUser = owner;
            BookClub.BookHiveApplicationUserId = ownerId;
            bookClubRepository.Update(BookClub);
            return BookClub;
        }

        public BookClub save(string name, string ownerId, string description)
        {
            BookHiveApplicationUser owner = userRepository.Get(ownerId);
            BookClub bookClub = new BookClub { BookHiveApplicationUserId = ownerId, BookHiveApplicationUser = owner, name = name, description = description };
            bookClubRepository.Insert(bookClub);
            return bookClub;
        }

        public List<BookHiveApplicationUser> getAllMembers(BookClub bookClub)
        {
            List<UserInBookClub> userInBookClubs = userInBookClubRepository.findByBookClub(bookClub);
            List<BookHiveApplicationUser> members = new List<BookHiveApplicationUser>();
            foreach (UserInBookClub userInBookClub in userInBookClubs)
            {
                    members.Add(userInBookClub.BookHiveApplicationUser);
            }
            return members;
        }
    }
}
