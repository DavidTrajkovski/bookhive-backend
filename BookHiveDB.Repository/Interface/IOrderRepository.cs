using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);

    }
}
