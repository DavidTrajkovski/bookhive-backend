using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IBookInWishListService
    {
        void removeBookFromMyWishlist(string userId, Guid bookId);
        void addBookToMyWishlist(string userId, Guid bookId);
        List<BookInWishList> getAllBookInWishlistForUser(string userId);
    }
}
