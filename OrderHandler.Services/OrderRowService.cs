using OrderHandler.Core;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Services
{
    public class OrderRowService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderRowService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<int> CreateOrder(Order orderToCreate)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrder(Order order)
        {
            _unitOfWork.OrderRows
        }

        public Task<List<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
