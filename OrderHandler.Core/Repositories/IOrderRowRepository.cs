using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core.Repositories
{
    public interface IOrderRowRepository : IRepository<OrderRow>
    {
        Task<int> CreateOrderRow(OrderRow orderRowToCreate);

        Task<List<OrderRow>> GetOrderRowsWithOrderByOrderIdAsync(int id);

        Task DeleteOrderRowsByOrderId(int orderId);
        Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName);
        Task<int> GetOrderRowNumberAsync(int orderId);
    }
}
