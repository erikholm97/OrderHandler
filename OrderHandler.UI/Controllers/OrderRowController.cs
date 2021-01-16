using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Models;

namespace OrderHandler.UI.Controllers
{
    public class OrderRowController : Controller
    {
        // GET: OrderRowController
        public async Task<IActionResult> Index(string articleName)
        {
            OrderRow orderRow = new OrderRow();
            List<OrderRowViewModel> orderView = new List<OrderRowViewModel>();

            var orderRows = orderRow.GetOrderRowsByArticle(articleName);

            if (!String.IsNullOrEmpty(articleName))
            {
                orderRows = orderRow.GetOrderRowsByArticle(articleName);
            }

            if(orderRows is null || orderRows.Count == 0)
            {
                orderRows = orderRow.GetAllOrderRows();

                
                    foreach (var orderRow1 in orderRows)
                    {
                        orderView.Add(new OrderRowViewModel()
                        {
                            ArticleAmount = orderRow1.ArticleAmount,
                            ArticleName = orderRow1.Article.ArticleName,
                            ArticleNumber = orderRow1.Article.ArticleNumber,
                            Price = orderRow1.Article.Price,
                            OrderId = orderRow1.OrderId
                        });
                    }
                
            }

            //Todo GetOrderRows by article.

            return View(orderView);
        }

        // GET: OrderRowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderRowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderRowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderRowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderRowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderRowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderRowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
