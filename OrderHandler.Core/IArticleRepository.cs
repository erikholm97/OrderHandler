using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public interface IArticleRepository
    {
        Task<Article> CreateArticle(Article articleToCreate);

        Task<Article> GetIfArticleByNameExist(string articleName);
        
    }
}
