﻿using OrderHandler.Core.Models;
using System.Threading.Tasks;

namespace OrderHandler.Core.Services
{
    interface IArticleService
    {
        Task<Article> CreateArticle(Article articleToCreate);

        Task<Article> GetIfArticleByNameExist(string articleName);
    }
}
