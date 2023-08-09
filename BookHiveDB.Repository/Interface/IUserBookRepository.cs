using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Interface
{
    public interface IUserBookRepository
    {
        IEnumerable<UserBook> GetAll();
        UserBook Get(Guid? id);
        void Insert(UserBook entity);
        void Update(UserBook entity);
        void Delete(UserBook entity);
        List<UserBook> FindByUser(BookHiveApplicationUser user);
        UserBook FindByUserAndBook(BookHiveApplicationUser user, Book Book);
    }
}
