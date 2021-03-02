using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Models;
using OrderHandler.UI.Helpers;
using OrderHandler.Core.Models;

namespace OrderHandler.UI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: OrderRowController
        public IActionResult Index(string articleName)
        {
            OrderRow or = new OrderRow();
            ArticleViewModel articlesWithOrderRows = new ArticleViewModel();
            articlesWithOrderRows.OrderRowsFound = 0;
            articlesWithOrderRows.OrderRow = new List<OrderRowViewModel>();

            try
            {
                var orderRows = or.GetOrderRowsByArticleName(articleName);

                foreach (var orderRow in orderRows)
                {
                    articlesWithOrderRows.OrderRow.Add(new OrderRowViewModel()
                    {
                        ArticleAmount = orderRow.ArticleAmount,
                        ArticleName = orderRow.Article.ArticleName,
                        ArticleNumber = orderRow.Article.ArticleNumber,
                        Price = orderRow.Article.Price,
                        OrderId = orderRow.OrderId,
                        OrderSum = OrderHelper.GetOrderSum(orderRow.Article.Price, orderRow.ArticleAmount),
                        CustomerName = orderRow.Order.CustomerName
                    });

                    articlesWithOrderRows.OrderRowSum += OrderHelper.GetOrderSum(orderRow.Article.Price, orderRow.ArticleAmount);
                    articlesWithOrderRows.OrderRowsFound++;
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

            return View(articlesWithOrderRows);
        }

        [HttpPost]
        public IActionResult CreateSearchString(string searchString)
        {
            return RedirectToAction("Index", new { articleName = searchString });
        }
    }
}
