using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IOrderRowRepository Artists { get; }

        IArticleRepository Articles { get; }
        Task<int> CommitAsync();
    }
}
