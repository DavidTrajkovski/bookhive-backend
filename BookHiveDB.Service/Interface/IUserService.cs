using System.Collections.Generic;
using BookHiveDB.Domain.Identity;

namespace BookHiveDB.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<string> BookHiveUserEmails();
        BookHiveApplicationUser findById(string id);
        BookHiveApplicationUser findByEmail(string email);
        BookHiveApplicationUser update(BookHiveApplicationUser user, string name, string surname, string email, string password, string confirmPassword);
    }
}
