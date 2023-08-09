using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Author> _entities;

        public AuthorRepository(ApplicationDbContext context)
        {
            this._context = context;
            _entities = context.Set<Author>();
        }

        public IEnumerable<Author> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public Author Get(Guid? id)
        {
            return _entities.Include(a => a.AuthoredBooks)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Author entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
