using OrderHandler.Core;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> CreateOrder(Order orderToCreate)
        {
            await _unitOfWork.Orders.AddAsync(orderToCreate);

            return orderToCreate.Id;
        }

        public async Task DeleteOrder(Order order)
        {
           _unitOfWork.Orders.Remove(order);
        }

        public async Task<List<Order>> GetAllOrders()
        {
           return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
