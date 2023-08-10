using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Exceptions;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Implementation
{
    public class BookShopService : IBookShopService
    {
        private readonly IBookShopRepository bookShopRepository;
        private readonly IBookService bookService;

        public BookShopService(IBookShopRepository bookShopRepository, IBookService bookService)
        {
            this.bookShopRepository = bookShopRepository;
            this.bookService = bookService;
        }

        public void DeleteById(Guid id)
        {
            BookShop entity = bookShopRepository.Get(id);
            bookShopRepository.Delete(entity);
        }

        public List<BookShop> findAllByName(string Containing)
        {
            return bookShopRepository.findAllByName(Containing);
        }

        public List<Book> GetBooksForBookshop(Guid bookshopId)
        {
            var bookshop = Get(bookshopId);
            if (bookshop is null) throw new EntityNotFoundException($"Bookshop with ID: {bookshopId} not found.");
            return bookshop.Books;
        }

        public BookShop Get(Guid? id)
        {
            return bookShopRepository.Get(id);
        }

        public List<BookShop> GetAll()
        {
            return bookShopRepository.GetAll().ToList();
        }

        public List<BookShop> getAllByBooks(Guid bookId)
        {
            Book book = bookService.findById(bookId);
            return bookShopRepository.getAllByBooks(book);
        }

        public void Insert(BookShop entity)
        {
            bookShopRepository.Insert(entity);
        }

        public void Update(BookShop entity)
        {
            bookShopRepository.Update(entity);
        }
    }
}
