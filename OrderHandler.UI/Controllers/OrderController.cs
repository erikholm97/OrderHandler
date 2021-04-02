using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public OrderController(IOrderService orderContext, IArticleService articleContext, IOrderRowService orderRowContext, IMapper mapper)
        {
            this._orderContext = orderContext;
            this._articleContext = articleContext;
            this._orderRowContext = orderRowContext;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderContext.GetAllOrders();

            var autoMappedOrders = _mapper.Map<List<Order>,List<OrderViewModel>> (orders);

            return View(autoMappedOrders);
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

                return RedirectToAction("CreateOrderRow", new { orderId = id });
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderRow(OrderRowViewModel orderRow)
        {
            try
            {
                Article articleToCreate = new Article();
                int articleId = 0;

                articleToCreate = await _articleContext.GetIfArticleByNameExist(orderRow.ArticleName);

                //Article exist in database
                if (articleToCreate != null)
                {
                    articleId = articleToCreate.Id;

                    //Overides users choosen article number since the item exists in the db.
                    orderRow.ArticleNumber = articleToCreate.ArticleNumber;
                }

                //Create new Article
                if (articleToCreate is null)
                {
                    articleToCreate = new Article()
                    {
                        ArticleName = orderRow.ArticleName,
                        Price = orderRow.Price,
                        ArticleNumber = orderRow.ArticleNumber
                    };

                    articleId = await _articleContext.CreateArticle(articleToCreate);
                }

                OrderRow orderRowToCreate = new OrderRow()
                {
                    ArticleId = articleId,
                    OrderId = orderRow.OrderId,
                    RowNumber = OrderHelper.GetOrderRowNumber(orderRow.OrderId),
                    ArticleAmount = orderRow.ArticleAmount,
                };

                int orderRowId = await _orderRowContext.CreateOrderRow(orderRowToCreate);

                return RedirectToAction("Details", new { id = orderRow.OrderId });
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Order order = new Order();
                order = await _orderContext.GetOrderById(id);

                OrderRow orderRows = new OrderRow();
                var listOfOrders =  await _orderRowContext.GetOrderRowsByOrderId(id);

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
                return View("Error", ex.Message);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var order = await _orderContext.GetOrderById(id);

                return View(order);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                return View(await _orderContext.GetOrderById(id));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Order order)
        {
            try
            {
                await _orderRowContext.DeleteOrderRowsByOrderId(order.Id);

                await _orderContext.DeleteOrder(order);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
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
                return View("Error", ex.Message);
            }
        }
    }
}