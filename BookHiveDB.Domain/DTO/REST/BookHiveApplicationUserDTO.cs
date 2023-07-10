using BookHiveDB.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookHiveDB.Domain.DTO.REST
{
    public class BookHiveApplicationUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCartDTO UserCart { get; set; }

    }
}
