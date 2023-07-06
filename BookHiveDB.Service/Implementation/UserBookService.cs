using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookHiveDB.Service.Implementation
{
    public class UserBookService : IUserBookService
    {
        private readonly IUserBookRepository userBookRepository;
        private readonly IUserService userService;
        private readonly IBookService bookService;

        public UserBookService(IUserBookRepository userBookRepository, IUserService userService, IBookService bookService)
        {
            this.userBookRepository = userBookRepository;
            this.userService = userService;
            this.bookService = bookService;
        }

        public void addBookToMyBooks(string userId, Guid bookId)
        {
            var user = userService.findById(userId);
            var book = bookService.findById(bookId);
            userBookRepository.Insert(new UserBook { Book = book, BookId = book.Id, BookHiveApplicationUser = user, UserId = user.Id, lastPageRead = 0 });

        }

        public void addBookToMyWishlist(Guid userId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public UserBook editLastPageReadForBook(string userId, Guid bookId, int lastPageRead)
        {
            BookHiveApplicationUser user = userService.findById(userId);
            Book book = bookService.findById(bookId);

            UserBook userbook = this.FindByUserAndBook(user, book);

            if (lastPageRead > book.totalPages)
                userbook.lastPageRead = book.totalPages;
            else
                userbook.lastPageRead = lastPageRead;

            userbook.lastPageRead = lastPageRead;
            return this.Update(userbook);
        }

        public List<UserBook> FindByUser(BookHiveApplicationUser user)
        {
            return userBookRepository.FindByUser(user);
        }

        public UserBook FindByUserAndBook(BookHiveApplicationUser User, Book Book)
        {
            return userBookRepository.FindByUserAndBook(User, Book);
        }


        public List<Book> getMyWishlist(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<UserBook> GetUserBooks()
        {
            return userBookRepository.GetAll().ToList();
        }

        public void RemoveFromMyBooks(Guid Id)
        {
            UserBook userBook = userBookRepository.Get(Id);
            userBookRepository.Delete(userBook);
        }


        public void removeBookFromMyWishlist(Guid userId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public UserBook Update(UserBook userBook)
        {
            userBookRepository.Update(userBook);
            return userBook;
        }

        public UserBook Get(Guid id)
        {
            return userBookRepository.Get(id);
        }
    }
}
