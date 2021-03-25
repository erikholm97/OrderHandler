using OrderHandler.Core;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OrderHandler.Services
{
    public class OrderRowService : IOrderRowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<OrderRow> CreateOrderRow(OrderRow orderRowToCreate)
        {
            await _unitOfWork.OrderRows.AddAsync(orderRowToCreate);

            return orderRowToCreate;
        }

        public async Task DeleteOrderRowsByOrderId(int orderId)
        {
            await _unitOfWork.OrderRows.DeleteOrderRowsByOrderId(orderId);
        }

        public async Task<List<OrderRow>> GetAllOrderRows()
        {
            var orderRows = await _unitOfWork.OrderRows.GetAllAsync();

            return orderRows.ToList();
        }

        public async Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName)
        {
            return await _unitOfWork.OrderRows.GetOrderRowsByArticleName(articleName);
        }

        public async Task<List<OrderRow>> GetOrderRowsByOrderId(int id)
        {
            return await _unitOfWork.OrderRows.GetOrderRowsWithOrderByOrderIdAsync(id);
        }

        Task<int> IOrderRowService.CreateOrderRow(OrderRow orderRowToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
