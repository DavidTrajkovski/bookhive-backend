using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Book> entities;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<Book>();
        }

        public void Delete(Book entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<Book> FindAllByIsValidTrue()
        {
            return entities.Where(z => z.IsValid == true).ToListAsync().Result;
        }

        public Book Get(Guid? id)
        {
            return entities
                .Include(z => z.Authors)
                .Include(z => z.BookShops)
                .SingleOrDefaultAsync(s => s.Id == id).Result;
        }

        public List<Book> GetAll()
        {
            return entities.Include(z => z.Authors).ToListAsync().Result.ToList();
        }

        public void Insert(Book entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Book entity)
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
