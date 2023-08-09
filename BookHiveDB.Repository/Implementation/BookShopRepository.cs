using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Implementation
{
    public class BookShopRepository : IBookShopRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<BookShop> entities;

        public BookShopRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<BookShop>();
        }

        public void Delete(BookShop entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<BookShop> findAllByName(string Containing)
        {
            return entities
                .Include(z => z.Books)
                .Where(s => s.name.Contains(Containing))
                .ToList();
        }

        public BookShop Get(Guid? id)
        {
            return entities
                .Include(bs => bs.Books)
                .SingleOrDefaultAsync(s => s.Id == id).Result;
        }

        public IEnumerable<BookShop> GetAll()
        {
            return entities
                .Include(z => z.Books)
                .ToListAsync().Result;
        }

        public List<BookShop> getAllByBooks(Book book)
        {
            var bookshopsByBook = entities
                .Include(bs => bs.Books)
                .Where(b => b.Books.Contains(book))
                .ToList();

            return bookshopsByBook;
        }

        public void Insert(BookShop entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookShop entity)
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
