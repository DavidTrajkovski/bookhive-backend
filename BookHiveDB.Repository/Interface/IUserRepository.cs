using BookHiveDB.Domain.Identity;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookHiveApplicationUser> GetAll();
        BookHiveApplicationUser Get(string id);
        public BookHiveApplicationUser FindByEmail(string email);
        void Insert(BookHiveApplicationUser entity);
        void Update(BookHiveApplicationUser entity);
        void Delete(BookHiveApplicationUser entity);
    }
}
