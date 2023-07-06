using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Author> entities;

        public AuthorRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Author>();
        }
        public IEnumerable<Author> GetAll()
        {
            return entities.AsEnumerable();
        }

        public Author Get(Guid? id)
        {
            return entities.Include(z=>z.authorBooks)
                .Include("authorBooks.Book")
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Author entity)
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
