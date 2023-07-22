using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Repository.Implementation
{
    public class BookClubRepository : IBookClubRepository
    {

        private readonly ApplicationDbContext context;
        private readonly IUserInBookClubRepository userInBookClubRepository;
        private readonly IUserRepository userRepository;
        private DbSet<BookClub> entities;

        public BookClubRepository(ApplicationDbContext context, IUserRepository userRepository, IUserInBookClubRepository userInBookClubRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.userInBookClubRepository = userInBookClubRepository;
            entities = context.Set<BookClub>();
        }

        public void addUserToBookclub(Guid? bookClubId, string userId)
        {
            BookClub BookClub = findById(bookClubId);
            BookHiveApplicationUser User = userRepository.Get(userId);
            userInBookClubRepository.addUserInBookclub(BookClub, User);
            context.SaveChanges();
        }

        public void removeUserToBookclub(Guid? bookClubId, string userId)
        {
            BookClub BookClub = findById(bookClubId);
            BookHiveApplicationUser User = userRepository.Get(userId);
            userInBookClubRepository.removeUserInBookclub(BookClub, User);
            context.SaveChanges();
        }

        public IEnumerable<BookClub> findAll()
        {
            return entities.Include(z => z.UserInBookClubs)
                .Include(z => z.BookHiveApplicationUser)
                .ToListAsync().Result;
        }

        public BookClub findById(Guid? bookClubId)
        {
            return entities
                .Include(z => z.UserInBookClubs)
                .Include(z => z.BookHiveApplicationUser)
                .Include(z => z.Topics)
                .SingleOrDefaultAsync(s => s.Id == bookClubId).Result;
        }

        public List<BookClub> findAllByNameContainingIgnoreCase(string containing)
        {
            return entities.Include(z => z.UserInBookClubs)
                .Include(z => z.BookHiveApplicationUser)
                .Where(b => b.name.Contains(containing)).ToList();
        }

        public List<BookClub> findBookClubsByMember(string userId)
        {
            List<BookClub> bookclubs = new List<BookClub>();
            //todo: mozhebi treba include
            foreach (UserInBookClub userInBookClub in userInBookClubRepository.findByMember(userId))
            {
                bookclubs.Add(userInBookClub.BookClub);
            }
            return bookclubs;

        }

        public void Insert(BookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
