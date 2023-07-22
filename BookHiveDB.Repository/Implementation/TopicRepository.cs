using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Repository.Implementation
{
    public class TopicRepository : ITopicRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Topic> entities;

        public TopicRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<Topic>();
        }

        public IEnumerable<Topic> findAll()
        {
            return entities.Include(z => z.BookHiveApplicationUser)
                .Include(z => z.PostsBelonging)
                .ToListAsync().Result;
        }

        public Topic findById(Guid? bookClubId)
        {
            return entities.Include(z => z.BookHiveApplicationUser)
                .Include(z => z.PostsBelonging)
                .SingleOrDefaultAsync(s => s.Id == bookClubId).Result;
        }

        public void Insert(Topic entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Topic entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Topic entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<Topic> findByBookClub(BookClub bookClub)
        {
            return entities
                .Include(z => z.BookHiveApplicationUser)
                .Include(z => z.PostsBelonging)
                .Where(b => b.BookClub.Equals(bookClub)).ToList();
        }

        public Topic findByTitle(string title)
        {
            return entities
                .Include(z => z.BookHiveApplicationUser)
                .Include(z => z.PostsBelonging)
                .SingleOrDefaultAsync(b => b.title.Equals(title)).Result;
        }
    }
}
