using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderHandler.Core.Models;
using OrderHandler.Core.Repositories;

namespace OrderHandler.Data.Repositories
{
    public class ArticleRepository : Repository<Article>
    {
        public ArticleRepository(ApplicationDbContext context)
            : base(context)
        { }

        public async Task<Article> CreateArticleAsync(Article articleToCreate)
        {
            throw new NotImplementedException();
        }

    
        public async Task<Article> GetIfArticleByNameExistAsync(string articleName)
        {
            throw new NotImplementedException();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
