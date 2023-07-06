using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IAuthorService
    {
        List<Author> findAll();
        Author findById(Guid id);
        Author add(String name, String surname, int age, String biography);
        Author edit(Guid id, String name, String surname, int age, String biography);
        Author Update(Author author);
        Author Insert(Author author);
        void deleteById(Guid id);
    }
}
