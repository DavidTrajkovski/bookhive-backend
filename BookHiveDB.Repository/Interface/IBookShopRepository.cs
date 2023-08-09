using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Interface
{
    public interface IBookShopRepository
    {
        IEnumerable<BookShop> GetAll();
        BookShop Get(Guid? id);
        void Insert(BookShop entity);
        void Update(BookShop entity);
        void Delete(BookShop entity);
        List<BookShop> getAllByBooks(Book Book);
        List<BookShop> findAllByName(string Containing);
    }
}
