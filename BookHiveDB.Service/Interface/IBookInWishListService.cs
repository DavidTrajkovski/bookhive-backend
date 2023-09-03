using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Service.Interface
{
    public interface IBookInWishListService
    {
        void removeBookFromMyWishlist(string userId, Guid bookId);
        void addBookToMyWishlist(string userId, Guid bookId);
        List<BookInWishList> getAllBookInWishlistForUser(string userId);
        void clearAllBoughtBooksFromWishlistForUser(string userId);
    }
}
