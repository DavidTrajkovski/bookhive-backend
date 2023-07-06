using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> orders;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            orders = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return orders.Include(z => z.User)
                .Include(z => z.BooksInOrders)
                .Include("BooksInOrders.Book")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return orders.Include(z => z.User)
               .Include(z => z.BooksInOrders)
               .Include("BooksInOrders.Book")
               .Include("BooksInOrders.Book.BookGenres.Genre")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
