using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<BookHiveApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BookHiveApplicationUser>();
        }

        public IEnumerable<BookHiveApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public BookHiveApplicationUser Get(string id)
        {
            return entities.Include(z => z.BookInWishLists)
               .Include(z => z.UserCart)
               .ThenInclude(s => s.BookInShoppingCarts)
               .ThenInclude(e => e.Book)
               .ThenInclude(b => b.Authors)
               .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(BookHiveApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookHiveApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookHiveApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public BookHiveApplicationUser FindByEmail(string email)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.BookInShoppingCarts")
               .Include("UserCart.BookInShoppingCarts.Book")
               .SingleOrDefault(s => s.Email == email);
        }

    }
}
