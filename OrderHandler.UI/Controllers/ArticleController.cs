using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Models;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using AutoMapper;
using System.Linq;

namespace OrderHandler.UI.Controllers
{
    public class ArticleController : Controller
    {
        public IArticleService _articleContext { get; set; }

        public IMapper _mapper;

        public ArticleController(IArticleService articleContext, IMapper mapper)
        {
            this._articleContext = articleContext;
            this._mapper = mapper;
        }

        // GET: OrderRowController
        public async Task<IActionResult> Index()
        {
            try
            {
                var articles = await _articleContext.GetAllArticles();

                var articlesModels = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

                return View(articlesModels.AsQueryable());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
