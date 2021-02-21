using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System.Threading.Tasks;

namespace OrderHandler.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Article> CreateArticle(Article articleToCreate)
        {
            throw new System.NotImplementedException();
        }

        public Task<Article> GetIfArticleByNameExist(string articleName)
        {
            throw new System.NotImplementedException();
        }
    }
}
