using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

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

        public void GetOrderRowsByOrderId(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderRows = db.OrderRows.Where(x => x.OrderId == id);

            }
        }
    }
}
