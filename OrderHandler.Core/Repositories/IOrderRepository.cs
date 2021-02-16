using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task <int> CreateOrder(Order orderToCreate);

        Task DeleteOrder(Order order);

        Task UpdateOrder(Order order);
    }
}
