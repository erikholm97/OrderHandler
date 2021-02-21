using OrderHandler.Core.Repositories;
using OrderHandler.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderHandler.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
            : base(context)
        { }
        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
