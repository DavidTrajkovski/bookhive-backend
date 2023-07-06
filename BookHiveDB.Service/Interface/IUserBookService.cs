using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IUserBookService
    {
        List<UserBook> GetUserBooks();
        List<UserBook> FindByUser(BookHiveApplicationUser user);
        UserBook FindByUserAndBook(BookHiveApplicationUser User, Book Book);
        void addBookToMyBooks(string userId, Guid bookId);
        UserBook editLastPageReadForBook(string userId, Guid bookId, int lastPageRead);
        UserBook Update(UserBook userBook);
        UserBook Get(Guid id);
        void RemoveFromMyBooks(Guid Id);
    }
}
