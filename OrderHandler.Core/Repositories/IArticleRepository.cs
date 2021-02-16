using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> CreateArticleAsync(Article articleToCreate);

        Task<Article> GetIfArticleByNameExistAsync(string articleName);
        
    }
}
