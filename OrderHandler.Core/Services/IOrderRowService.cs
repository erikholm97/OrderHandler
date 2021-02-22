using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core.Services
{
    public interface IOrderRowService
    {
        Task<OrderRow> CreateOrderRow(OrderRow orderRowToCreate);

        Task<List<OrderRow>> GetOrderRowsByOrderId(int id);

        Task<List<OrderRow>> GetAllOrderRows();

        Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName);
        Task DeleteOrderRowsByOrderId(int orderId);
    }
}
