using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.Services
{
    interface IArticleService
    {
        Task<Article> CreateArticle(Article articleToCreate);

        Task<Article> GetIfArticleByNameExist(string articleName);
    }
}
