﻿using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Interface
{
    public interface IBookShopService
    {
        List<BookShop> GetAll();
        BookShop Get(Guid? id);
        void Insert(BookShop entity);
        void Update(BookShop entity);
        void DeleteById(Guid id);
        List<BookShop> getAllByBooks(Guid bookId);
        List<BookShop> findAllByName(string Containing);
        List<Book> GetBooksForBookshop(Guid bookshopId);
    }
}
