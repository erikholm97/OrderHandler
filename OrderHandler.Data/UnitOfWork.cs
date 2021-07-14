using OrderHandler.Core;
using OrderHandler.Core.Repositories;
using OrderHandler.Data.Repositories;
using System.Threading.Tasks;

namespace OrderHandler.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private OrderRepository _orderRepository;
        private ArticleRepository _articleRepository;
        private OrderRowRepository _orderRowRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);

        public IArticleRepository Articles => _articleRepository = _articleRepository ?? new ArticleRepository(_context);

        public IOrderRowRepository OrderRows => _orderRowRepository = _orderRowRepository ?? new OrderRowRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
