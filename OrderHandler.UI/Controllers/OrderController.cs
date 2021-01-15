using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Models;

namespace OrderHandler.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            Order order = new Order();

            List<Order> orders = order.GetAllOrders();

            return View(orders);
        }

        public IActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                Order order = new Order();
                order = order.GetOrderById(id.Value);

                OrderViewModel1 orderView = new OrderViewModel1()
                {
                    Id = order.Id,
                    CustomerName = order.CustomerName,
                };

                return View(order);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel1 order)
        {
            Order orderToCreate = new Order()
            {
                CustomerName = order.CustomerName
            };

            if (order.Id.HasValue)
            {
                bool orderWithSameIdExist = orderToCreate.GetOrderById(order.Id.Value) != null ? true : false;
                return View();
            }

            int id = orderToCreate.CreateOrder(orderToCreate);

            return RedirectToAction("CreateOrderRow", id);

            //Todo se till att id kommer in i create

        }

        public IActionResult CreateOrderRow(int id)
        {
            OrderRowViewModel orderRow = new OrderRowViewModel();
            if (id > 0)
            {
                orderRow.OrderId = id;
                return View(orderRow);
            }

            return View();

        }

        [HttpPost]
        public IActionResult CreateOrderRow(OrderRowViewModel orderRow)
        {
            Article articleToCreate = new Article()
            {
                ArticleName = orderRow.ArticleName,
                Price = orderRow.Price,
                ArticleNumber = orderRow.ArticleNumber
            };

            int articleId = articleToCreate.CreateArticle(articleToCreate);

            OrderRow orderRowToCreate = new OrderRow()
            {
                ArticleId = articleId,
                OrderId = orderRow.OrderId.Value,
                RowNumber = 1,
                ArticleAmount = orderRow.ArticleAmount,
            };

            int orderRowId = orderRowToCreate.CreateOrderRow(orderRowToCreate);



            return RedirectToAction("Create", orderRow.OrderId.Value);
        }

        public IActionResult Details(int id)
        {
            Order order = new Order();
            order = order.GetOrderById(id);

            OrderRow orderRows = new OrderRow();
            var listOfOrders = orderRows.GetOrderRowsByOrderId(id);

            OrderViewModel1 orderView = new OrderViewModel1()
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
            };

            orderView.OrderRow = new List<OrderRowViewModel>();

            if (listOfOrders.Count > 0)
            {
                foreach (var orderRow in listOfOrders)
                {
                    orderView.OrderRow.Add(new OrderRowViewModel()
                    {
                        ArticleAmount = orderRow.ArticleAmount,
                        ArticleName = orderRow.Article.ArticleName,
                        ArticleNumber = orderRow.Article.ArticleNumber,
                        Price = orderRow.Article.Price
                    });
                }
            }

            return View(orderView);
        }

        public IActionResult Edit(int id)
        {
            Order order = new Order();

            return View(order.GetOrderById(id));
        }

        public IActionResult Delete(int id)
        {
            Order order = new Order();

            order = order.GetOrderById(id);

            order.DeleteOrder(order);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            order.DeleteOrder(order);

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            order.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}