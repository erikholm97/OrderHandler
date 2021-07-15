using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderHandler.Core.Models;
using OrderHandler.Core.Services;
using OrderHandler.Data;
using OrderHandler.UI.Helpers;
using OrderHandler.UI.Models;

namespace OrderHandler.UI.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderContext { get; set; }

        public IArticleService _articleContext { get; set; }

        public IOrderRowService _orderRowContext { get; set; }

        public IMapper _mapper;

        public OrderController(IOrderService orderContext,
                               IArticleService articleContext,
                               IOrderRowService orderRowContext,
                               IMapper mapper)
        {
            this._orderContext = orderContext;
            this._articleContext = articleContext;
            this._orderRowContext = orderRowContext;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = await _orderContext.GetAllOrders();

                var autoMappedOrders = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

                return View(autoMappedOrders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel order)
        {
            try
            {
                var orderToCreate = _mapper.Map<OrderViewModel, Order>(order);

                int id = await _orderContext.CreateOrder(orderToCreate);

                return RedirectToAction("CreateOrderRowByOrderId", new { orderId = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IActionResult CreateOrderRowByOrderId(int orderId)
        {
            return View("CreateOrderRow", new OrderRowViewModel { OrderId = orderId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderRowByOrderId(OrderRowViewModel orderRow)
        {
            try
            {
                Article articleToCreate = await _articleContext.GetIfArticleByNameExist(orderRow.ArticleName);

                if (articleToCreate != null)
                {
                    articleToCreate.Id = articleToCreate.Id;

                    orderRow.ArticleNumber = articleToCreate.ArticleNumber;
                }

                if (articleToCreate is null)
                {
                    articleToCreate = new Article()
                    {
                        ArticleName = orderRow.ArticleName,
                        Price = orderRow.Price,
                        ArticleNumber = orderRow.ArticleNumber
                    };

                    articleToCreate.Id = await _articleContext.CreateArticle(articleToCreate);
                }

                OrderRow orderRowToCreate = new OrderRow()
                {
                    ArticleId = articleToCreate.Id,
                    OrderId = orderRow.OrderId,
                    RowNumber = await _orderRowContext.GetOrderRowNumber(orderRow.OrderId),
                    ArticleAmount = orderRow.ArticleAmount,
                };

                await _orderRowContext.CreateOrderRow(orderRowToCreate);

                return RedirectToAction("Edit", new { id = orderRow.OrderId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Order order = new Order();
                order = await _orderContext.GetOrderById(id);

                OrderRow orderRows = new OrderRow();
                var listOfOrders = await _orderRowContext.GetOrderRowsByOrderId(id);

                OrderViewModel orderView = new OrderViewModel()
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
                Console.WriteLine(ex);
                throw;
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Order order = new Order();
                order = await _orderContext.GetOrderById(id);

                OrderRow orderRows = new OrderRow();
                var listOfOrders = await _orderRowContext.GetOrderRowsByOrderId(id);

                OrderViewModel orderView = new OrderViewModel()
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
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            try
            {
                var orderToUpdate = await _orderContext.GetOrderById(order.Id);

                await _orderContext.UpdateOrder(orderToUpdate, order);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return View(await _orderContext.GetOrderById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order order)
        {
            try
            {
                await _orderRowContext.DeleteOrderRowsByOrderId(order.Id);

                await _orderContext.DeleteOrder(order);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}