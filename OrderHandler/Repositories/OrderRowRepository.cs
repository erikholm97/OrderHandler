using OrderHandler.Core.Models;
using OrderHandler.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Data.Repositories
{
    public class OrderRowRepository : Repository<OrderRow>, IOrderRowRepository
    {
        private ApplicationDbContext context;

        public OrderRowRepository(ApplicationDbContext context)
           : base(context)
        { }

        public Task<int> CreateOrderRow(OrderRow orderRowToCreate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderRowsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderRow>> GetAllOrderRows()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderRow>> GetOrderRowsByOrderId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
