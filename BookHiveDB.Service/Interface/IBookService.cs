using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Models;
using BookHiveDB.Domain.Dtos.REST.Book;
using BookHiveDB.Domain.Dtos.Rest;

namespace BookHiveDB.Service.Interface
{
    public interface IBookService
    {

        BookFilterResult GetBooksByCriteria(int page, int pageSize, string nameSearch, List<string> genres);
        List<Book> findAll();
        List<String> findAllGenres();
        Book findById(Guid id);
        Book add(string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds);

        Book edit(Guid id, string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds);

        Book CreateNewBook(Book Book);

        Book Update(Book book);
        void deleteById(Guid id);

        bool AddToShoppingCart(Domain.Dtos.Rest.ShoppingCart.AddToShoppingCartDto item, string userID);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
    }
}
