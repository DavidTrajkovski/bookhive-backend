using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Interface
{
    public interface IBookService
    {
        List<Book> findAll();
        Book findById(Guid id);
        Book add(string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds);

        Book edit(Guid id, string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds);

        Book CreateNewBook(Book Book);

        Book Update(Book book);
        void deleteById(Guid id);

        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
    }
}
