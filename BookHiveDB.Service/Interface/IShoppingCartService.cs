using BookHiveDB.Domain.DTO;
using System;
using BookHiveDB.Domain.Dtos.Mvc;

namespace BookHiveDB.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteBookFromShoppingCart(string userId, Guid productId);
        bool order(string userId);
    }
}
