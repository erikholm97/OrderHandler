using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler.Data
{
    public class OrderRow
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RowNumber { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int ArticleAmount { get; set; }

        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int CreateOrderRow(OrderRow orderRowToCreate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.OrderRows.Add(orderRowToCreate);

                db.SaveChanges();

                return orderRowToCreate.Id;
            }
        }

        public List<OrderRow> GetOrderRowsByOrderId(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderRows = db.OrderRows.Include(x => x.Article).Where(x => x.OrderId == id).ToList();

                return orderRows;
            }
        }

        public List<OrderRow> GetAllOrderRows()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderRows = db.OrderRows.Include(x => x.Article).ToList();

                return orderRows;
            }
        }

        public List<OrderRow> GetOrderRowsByArticle(string articleName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderRowsByArticle = db.OrderRows.Include(x => x.Article).Where(x => x.Article.ArticleName == articleName
                || x.Article.ArticleName.Contains(articleName)).ToList();

                return orderRowsByArticle;
            }
        }
    }
}
