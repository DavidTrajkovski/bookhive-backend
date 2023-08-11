using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Models;
using BookHiveDB.Domain.Enumerations;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Service.Interface
{
    public interface IBookService
    {

        List<BookDto> GetBooksByCriteria(int page, int pageSize, string nameSearch, List<Genre> genres);
        List<Book> findAll();
        List<String> findAllGenres();
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
