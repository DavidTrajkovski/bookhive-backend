using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Repository.Interface
{
    public interface IBookInWishListRepository
    {
        List<BookInWishList> GetAll();
        BookInWishList Get(Guid? id);
        void Insert(BookInWishList entity);
        void Update(BookInWishList entity);
        void Delete(BookInWishList entity);
        List<BookInWishList> FindByUser(BookHiveApplicationUser user);
        BookInWishList FindByUserAndBook(BookHiveApplicationUser user, Book Book);
    }
}
