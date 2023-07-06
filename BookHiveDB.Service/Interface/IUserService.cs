using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IUserService
    {
        BookHiveApplicationUser findById(string id);
        BookHiveApplicationUser findByEmail(string email);
        BookHiveApplicationUser update(BookHiveApplicationUser user, string name, string surname, string email, string password, string confirmPassword);
    }
}
