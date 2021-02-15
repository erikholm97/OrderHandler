using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task <int> CreateOrder(Order orderToCreate);

        Task DeleteOrder(Order order);

        Task UpdateOrder(Order order);
    }
}
