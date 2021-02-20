using OrderHandler.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IOrderRowRepository OrderRows { get; }
        IArticleRepository Articles { get; }
        Task<int> CommitAsync();
    }
}
