using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Implementation
{
    public class BookInWishListService : IBookInWishListService
    {

        private readonly IBookInWishListRepository bookInWishListRepository;
        private readonly IBookRepository bookRepository;
        private readonly IUserRepository userRepository;

        public BookInWishListService(IBookInWishListRepository bookInWishListRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            this.bookInWishListRepository = bookInWishListRepository;
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public List<BookInWishList> getAllBookInWishlistForUser(string userId)
        {
            BookHiveApplicationUser user = userRepository.Get(userId);
            return bookInWishListRepository.FindByUser(user);
        }

        public void addBookToMyWishlist(string userId, Guid bookId)
        {
            BookHiveApplicationUser user = userRepository.Get(userId);
            Book book = bookRepository.Get(bookId);
            BookInWishList obj = new BookInWishList { User = user, UserId = userId, Book = book, BookId = bookId };
            bookInWishListRepository.Insert(obj);
        }

        public void removeBookFromMyWishlist(string userId, Guid bookId)
        {
            BookHiveApplicationUser user = userRepository.Get(userId);
            Book book = bookRepository.Get(bookId);
            BookInWishList obj = bookInWishListRepository.FindByUserAndBook(user, book);
            bookInWishListRepository.Delete(obj);
        }
    }
}
