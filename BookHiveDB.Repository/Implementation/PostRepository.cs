using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Implementation
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<Post> entities;

        public PostRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<Post>();
        }

        public IEnumerable<Post> findAll()
        {
            return entities.Include(z => z.Topic)
                .Include(z => z.BookHiveApplicationUser)
                .ToListAsync()
                .Result;
        }

        public Post findById(Guid? postId)
        {
            return entities.Include(z => z.Topic)
                .Include(z => z.BookHiveApplicationUser)
                .SingleOrDefaultAsync(s => s.Id == postId)
                .Result;
        }

        public void Insert(Post entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Post entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Post entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<Post> findByTopic(Topic topic)
        {
            List<Post> posts = new List<Post>();
            posts = entities.Include(z => z.Topic)
                .Include(z => z.BookHiveApplicationUser)
                .Where(z => z.Topic.Equals(topic))
                .ToList();
            return posts; 
        }
    }
}
