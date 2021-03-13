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
        private ApplicationDbContext _context;

        public OrderRowRepository(ApplicationDbContext context)
           : base(context)
        { }

        public async Task<int> CreateOrderRow(OrderRow orderRowToCreate)
        {
           await _context.OrderRows.AddAsync(orderRowToCreate);

            return orderRowToCreate.Id;
        }

        public async Task DeleteOrderRowsByOrderId(int orderId)
        {
            var orderrows = _context.OrderRows.Where(x => x.OrderId == orderId).ToList();

            _context.OrderRows.RemoveRange(orderrows);
        }

        public async Task<List<OrderRow>> GetOrderRowsByArticleName(string articleName)
        {
            return await _context.OrderRows.Include(x => x.Article).Where(x => x.Article.ArticleName == articleName).ToListAsync();
        }

        public async Task<List<OrderRow>> GetOrderRowsByOrderIdAsync(int orderId)
        {
           return await _context.OrderRows.Where(x => x.OrderId == orderId).ToListAsync();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
