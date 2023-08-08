using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
