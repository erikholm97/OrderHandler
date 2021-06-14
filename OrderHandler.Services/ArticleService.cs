using OrderHandler.Core;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using System.Collections.Generic;
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

        public async Task<int> CreateArticle(Article articleToCreate)
        {
            await _unitOfWork.Articles.AddAsync(articleToCreate);

            return articleToCreate.Id;
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return await _unitOfWork.Articles.GetAllAsync();
        }

        public async Task<Article> GetIfArticleByNameExist(string articleName)
        {
            return await _unitOfWork.Articles.GetIfArticleByNameExistAsync(articleName);
        }
    }
}
