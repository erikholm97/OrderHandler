using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Data;
using OrderHandler.UI.Helpers;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel1 order)
        {
            try
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

                return RedirectToAction("CreateOrderRow", new { orderId = id });
            } 
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult CreateOrderRow(int orderId)
        {
            try
            {
                OrderRowViewModel orderRow = new OrderRowViewModel();
                orderRow.OrderId = orderId;

                return View(orderRow);
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOrderRow(OrderRowViewModel orderRow)
        {
            try
            {
                Article articleToCreate = new Article();
                int articleId = 0;


                articleToCreate = articleToCreate.GetIfArticleByNameExist(orderRow.ArticleName);

                //Article exist in database
                if (articleToCreate != null)
                {
                    articleId = articleToCreate.Id;

                    //Overides users choosen article number since the item exists in the db.
                    orderRow.ArticleNumber = articleToCreate.ArticleNumber;
                }              
                
                //Create new Article
                if(articleToCreate is null)
                {
                    articleToCreate = new Article()
                    {
                        ArticleName = orderRow.ArticleName,
                        Price = orderRow.Price,
                        ArticleNumber = orderRow.ArticleNumber
                    };

                    articleId = articleToCreate.CreateArticle(articleToCreate);
                }

                OrderRow orderRowToCreate = new OrderRow()
                {
                    ArticleId = articleId,
                    OrderId = orderRow.OrderId,
                    RowNumber = OrderHelper.GetOrderRowNumber(orderRow.OrderId),
                    ArticleAmount = orderRow.ArticleAmount,
                };

                int orderRowId = orderRowToCreate.CreateOrderRow(orderRowToCreate);

                return RedirectToAction("Details", new { id = orderRow.OrderId });
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult Details(int id)
        {
            try
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
                    int orderRowNr = 1;

                    foreach (var orderRow in listOfOrders)
                    {
                        orderView.OrderRow.Add(new OrderRowViewModel()
                        {
                            ArticleAmount = orderRow.ArticleAmount,
                            ArticleName = orderRow.Article.ArticleName,
                            ArticleNumber = orderRow.Article.ArticleNumber,
                            Price = orderRow.Article.Price,
                            OrderId = order.Id,
                            OrderSum = OrderHelper.GetOrderSum(orderRow.Article.Price, orderRow.ArticleAmount),
                            OrderRowNr = orderRowNr
                        });

                        orderRowNr++;
                    }
                }
                return View(orderView);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }

        public IActionResult Edit(int id)
        {
            try
            {
                Order order = new Order();

                return View(order.GetOrderById(id));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Order order = new Order();

                order = order.GetOrderById(id);

                return View(order);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            try
            {
                OrderRow orderRow = new OrderRow();

                orderRow.DeleteOrderRowsByOrderId(order.Id);

                order.DeleteOrder(order);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
           
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            try
            {
                order.UpdateOrder(order);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}