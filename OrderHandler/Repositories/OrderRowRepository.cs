using Microsoft.EntityFrameworkCore;
using OrderHandler.Core.Models;
using OrderHandler.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Data.Repositories
{
    public class OrderRowRepository : Repository<OrderRow>, IOrderRowRepository
    {
  
        public OrderRowRepository(ApplicationDbContext context)
           : base(context)
        { }

        public async Task<int> CreateOrderRow(OrderRow orderRowToCreate)
        {
           await ApplicationDbContext.OrderRows.AddAsync(orderRowToCreate);

            return orderRowToCreate.Id;
        }

        public async Task DeleteOrderRowsByOrderId(int orderId)
        {
            var orderrows = ApplicationDbContext.OrderRows.Where(x => x.OrderId == orderId).ToList();

            ApplicationDbContext.OrderRows.RemoveRange(orderrows);
        }

        public async Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName)
        {
            return await ApplicationDbContext.OrderRows.Include(x => x.Article).Include(x => x.Order).Where(x => x.Article.ArticleName == articleName).ToListAsync();
        }

        public async Task<List<OrderRow>> GetOrderRowsByOrderIdAsync(int orderId)
        {
           return await ApplicationDbContext.OrderRows.Where(x => x.OrderId == orderId).ToListAsync();
        }

        public async Task<List<OrderRow>> GetOrderRowsWithOrderByOrderIdAsync(int id)
        {
            return await ApplicationDbContext.OrderRows.Include(x => x.Order).Include(x => x.Article).Where(x => x.Id == id).ToListAsync();
        }

        public async Task<int> GetOrderRowNumberAsync(int orderId)
        {
            var orderRows = await ApplicationDbContext.OrderRows.Where(x => x.RowNumber == orderId).ToListAsync();

            if (orderRows.Count == 0)
            {
                return 1;
            }

            return orderRows.Select(x => x.RowNumber).Max();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
