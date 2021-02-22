using OrderHandler.Core;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System.Threading.Tasks;

namespace OrderHandler.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Article> CreateArticle(Article articleToCreate)
        {
            await _unitOfWork.Articles.AddAsync(articleToCreate);

            return articleToCreate;
        }

        public async Task<Article> GetIfArticleByNameExist(string articleName)
        {
            return await _unitOfWork.Articles.GetIfArticleByNameExistAsync(articleName);
        }
    }
}
