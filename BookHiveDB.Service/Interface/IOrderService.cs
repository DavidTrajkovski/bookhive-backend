using System;
using System.Collections.Generic;
using System.Text;
using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;

namespace BookHiveDB.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
