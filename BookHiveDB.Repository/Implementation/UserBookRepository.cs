using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookHiveDB.Repository.Implementation
{
    public class UserBookRepository : IUserBookRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<UserBook> entities;

        public UserBookRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<UserBook>();
        }

        public void Delete(UserBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<UserBook> FindByUser(BookHiveApplicationUser user)
        {
            return entities.Include(z=>z.Book)
                .Include("Book.authorBooks.Author")
                .Where(s => s.UserId.Equals(user.Id))
                .ToList();
        }

        public UserBook FindByUserAndBook(BookHiveApplicationUser user, Book Book)
        {
            return entities.SingleOrDefaultAsync(s => s.UserId.Equals(user.Id) && s.BookId.Equals(Book.Id)).Result;
        }

        public UserBook Get(Guid? id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id).Result;
        }

        public IEnumerable<UserBook> GetAll()
        {
            return entities.ToListAsync().Result;
        }

        public void Insert(UserBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(UserBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
