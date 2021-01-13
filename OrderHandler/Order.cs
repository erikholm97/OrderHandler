using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        
        public List<Order> GetAllOrders()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var orders = db.Orders.ToList();

                return orders;
            };
        }

        public Order GetOrderById(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var order = db.Orders.FirstOrDefault(x => x.Id == id);

                return order;
            };
        }

        public int CreateOrder(Order orderToCreate)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Orders.Add(orderToCreate);

                db.SaveChanges();

                return orderToCreate.Id;

            }
        }

        public void DeleteOrder(Order order)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderToDelete = db.Orders.FirstOrDefault(x => x.Id == order.Id);

                db.Remove(orderToDelete);
                db.SaveChanges();
            };
        }

        public void UpdateOrder(Order order)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderToUpdate = db.Orders
                    .Where(o => o.Id == order.Id).FirstOrDefault();

                orderToUpdate.CustomerName = order.CustomerName;

                db.SaveChanges();

            }
        }

        public void GetOrderWithOrderRows(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderWithOrderRows = db.OrderRows.Include(x => x.Article).FirstOrDefault(x => x.OrderId == id);

            }
        }
    }
}

