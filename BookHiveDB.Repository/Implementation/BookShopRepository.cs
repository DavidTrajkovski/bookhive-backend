using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return entities.Include(z => z.BookInBookShops)
                .Include("BookInBookShops.Book")
                .Where(s => s.name.Contains(Containing))
                .ToList();
        }

        public BookShop Get(Guid? id)
        {
            return entities.Include(z=>z.BookInBookShops)
                .Include("BookInBookShops.Book")
                .SingleOrDefaultAsync(s => s.Id == id).Result;
        }

        public IEnumerable<BookShop> GetAll()
        {
            return entities.Include(z => z.BookInBookShops)
                .Include("BookInBookShops.Book")
                .ToListAsync().Result;
        }

        public List<BookShop> getAllByBooks(Book Book)
        {
            List<BookShop> bookshops = new List<BookShop>();

            foreach(BookShop BookShop in entities.Include(z => z.BookInBookShops).Include("BookInBookShops.Book").ToList())
            {
                foreach(BookInBookShop BookInBookShop in BookShop.BookInBookShops)
                {
                    if (BookInBookShop.Book.Equals(Book))
                    {
                        bookshops.Add(BookShop);
                    }
                }
            }

            //json
            foreach(BookShop bookShop in bookshops)
            {
                bookShop.BookInBookShops = null;
            }


            return bookshops;
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
