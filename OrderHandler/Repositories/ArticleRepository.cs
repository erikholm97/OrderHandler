using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderHandler.Core.Models;
using OrderHandler.Core.Repositories;

namespace OrderHandler.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context)
            : base(context)
        { }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
