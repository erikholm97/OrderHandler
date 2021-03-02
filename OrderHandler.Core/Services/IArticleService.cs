using OrderHandler.Core.Models;
using System.Threading.Tasks;

namespace OrderHandler.Core.Services
{
    public interface IArticleService
    {
        Task<int> CreateArticle(Article articleToCreate);

        Task<Article> GetIfArticleByNameExist(string articleName);
    }
}
