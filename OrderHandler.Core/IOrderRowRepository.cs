using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public interface IOrderRowRepository
    {
        Task<int> CreateOrderRow(OrderRow orderRowToCreate);

        Task<List<OrderRow>> GetOrderRowsByOrderId(int id);

        Task<List<OrderRow>> GetAllOrderRows();

        Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName);

        Task DeleteOrderRowsByOrderId(int orderId);

    }
}
