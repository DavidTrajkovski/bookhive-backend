using System.Collections.Generic;
using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
