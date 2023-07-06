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
    public class UserInBookClubRepository : IUserInBookClubRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<UserInBookClub> entities;

        public UserInBookClubRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<UserInBookClub>();
        }

        public void Delete(UserInBookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public UserInBookClub Get(Guid? id)
        {
            return entities.Include(z => z.BookClub).Include(z => z.BookHiveApplicationUser).SingleOrDefaultAsync(s => s.Id == id).Result;
        }

        public IEnumerable<UserInBookClub> GetAll()
        {
            return entities.Include(z => z.BookClub).Include(z => z.BookHiveApplicationUser).ToListAsync().Result;
        }

        public void Insert(UserInBookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(UserInBookClub entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void addUserInBookclub(BookClub bookClub, BookHiveApplicationUser user)
        {
            UserInBookClub entity = new UserInBookClub { BookClub = bookClub, BookClubId = bookClub.Id, BookHiveApplicationUser = user, UserId = user.Id };
            Insert(entity);
        }

        public void removeUserInBookclub(BookClub bookClub, BookHiveApplicationUser user)
        {
            UserInBookClub entity = entities.SingleOrDefaultAsync(s => s.BookClubId == bookClub.Id && s.UserId == user.Id).Result;
            Delete(entity);
        }

        public List<UserInBookClub> findByMember(string userId)
        {
            return entities.Include(z => z.BookClub)
                .Where(z => z.BookHiveApplicationUser.Id.Equals(userId))
                .ToList();
        }

        public List<UserInBookClub> findByBookClub(BookClub bookClub)
        {
            return entities.Include(z => z.BookHiveApplicationUser)
                .Where(z => z.BookClub.Equals(bookClub))
                .ToList();
        }

    }
}
