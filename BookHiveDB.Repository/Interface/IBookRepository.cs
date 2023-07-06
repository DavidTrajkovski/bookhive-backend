using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Repository.Interface
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(Guid? id);
        void Insert(Book entity);
        void Update(Book entity);
        void Delete(Book entity);
        List<Book> FindAllByIsValidTrue();

    }
}
