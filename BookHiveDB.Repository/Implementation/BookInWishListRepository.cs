using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookHiveDB.Repository.Implementation
{
    public class BookInWishListRepository : IBookInWishListRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<BookInWishList> entities;

        public BookInWishListRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<BookInWishList>();
        }

        public void Delete(BookInWishList entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<BookInWishList> FindByUser(BookHiveApplicationUser user)
        {
            return entities
                .Include(b => b.Book).Include("Book.authorBooks.Author")
                .Include(b => b.User)
                .Where(s => s.UserId.Equals(user.Id))
                .ToList();
        }

        public BookInWishList FindByUserAndBook(BookHiveApplicationUser user, Book Book)
        {
            return entities
                .Include(b => b.Book).Include("Book.authorBooks.Author")
                .Include(b => b.User)
                .SingleOrDefaultAsync(s => s.UserId.Equals(user.Id) && s.BookId.Equals(Book.Id))
                .Result;
        }

        public BookInWishList Get(Guid? id)
        {
            return entities
                .Include(b => b.Book).Include("Book.authorBooks.Author")
                .Include(b => b.User)
                .SingleOrDefaultAsync(s => s.Id == id)
                .Result;
        }

        public List<BookInWishList> GetAll()
        {
            return entities
                .Include(b => b.Book).Include("Book.authorBooks.Author")
                .Include(b => b.User)
                .ToListAsync()
                .Result;
        }

        public void Insert(BookInWishList entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookInWishList entity)
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
