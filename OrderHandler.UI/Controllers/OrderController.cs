﻿using System;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            Order orderToCreate = new Order()
            {
                CustomerName = order.CustomerName
            };

            Article articleToCreate = new Article()
            {
                ArticleName = order.ArticleName,
                Price = order.Price,
                ArticleNumber = order.ArticleNumber
            };

            OrderRow orderRowToCreate = new OrderRow()
            {
                OrderId = orderToCreate.Id,
                ArticleId = articleToCreate.Id, //Todo propery for orderrow in viewmodel
                RowNumber = 1,
                ArticleAmount = order.ArticleAmount,

            };

            orderToCreate.CreateOrder(orderToCreate);

            return RedirectToAction("Index");
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