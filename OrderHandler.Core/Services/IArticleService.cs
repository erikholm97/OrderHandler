using OrderHandler.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderHandler.Core.Services
{
    public interface IArticleService
    {
        Task<int> CreateArticle(Article articleToCreate);

        Task<IEnumerable<Article>> GetAllArticles();

        Task<Article> GetIfArticleByNameExist(string articleName);
    }
}
