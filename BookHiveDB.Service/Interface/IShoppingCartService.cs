using BookHiveDB.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteBookFromShoppingCart(string userId, Guid productId);
        bool order(string userId);
    }
}
