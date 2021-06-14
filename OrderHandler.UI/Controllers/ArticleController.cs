﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Models;
using OrderHandler.UI.Helpers;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace OrderHandler.UI.Controllers
{
    public class ArticleController : Controller
    {
        public IArticleService _articleContext { get; set; }

        public IOrderRowService _orderRowContext { get; set; }

        public IMapper _mapper;

        public ArticleController(IArticleService articleContext, IMapper mapper)
        {
            this._articleContext = articleContext;
            this._orderRowContext = _orderRowContext;
            this._mapper = mapper;
        }
        // GET: OrderRowController
        public async Task<IActionResult> Index()
        {
            try
            {
                var articles = await _articleContext.GetAllArticles();

                var articlesModels = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>> (articles);

                return View(articlesModels.AsQueryable());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateSearchString(string searchString)
        {
            return RedirectToAction("Index", new { articleName = searchString });
        }
    }
}
