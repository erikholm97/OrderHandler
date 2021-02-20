using OrderHandler.Core.Repositories;
using OrderHandler.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderHandler.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
            : base(context)
        { }

        public Task<int> CreateOrder(Order orderToCreate)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Order>> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
