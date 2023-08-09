using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository repository;

        public AuthorService(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        public Author add(string name, string surname, int age, string biography)
        {
            Author author = new Author { Name = name, Surname = surname, Age = age, Biography = biography };
            repository.Insert(author);
            return author;
        }

        public void deleteById(Guid id)
        {
            Author author = repository.Get(id);
            repository.Delete(author);
        }

        public Author edit(Guid id, string name, string surname, int age, string biography)
        {
            Author author = repository.Get(id);
            author.Name = name;
            author.Surname = surname;
            author.Age = age;
            author.Biography = biography;
            repository.Update(author);
            return author;

        }

        public List<Author> findAll()
        {
            return repository.GetAll().ToList();
        }

        public Author findById(Guid id)
        {
            return repository.Get(id);
        }

        public Author Update(Author author)
        {
            repository.Update(author);
            return author;
        }
        public Author Insert(Author author)
        {
            repository.Insert(author);
            return author;
        }
    }
}
