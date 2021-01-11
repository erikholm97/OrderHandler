using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHandler.Data
{
    public static class DataSeeder
    {
      
        public static void SeedData(ModelBuilder modelBuilder)
        {
            //Todo separera och skapa foreignkeys
            modelBuilder.Entity<Order>().HasData(
                new Order 
                {   
                    Id = 1, 
                    CustomerName = "CGI", 
                    OrderRows = new List<OrderRow>()
                    {
                        new OrderRow()
                        {
                            Id = 1,
                            Article = new Article()
                            {
                               Id = 1,
                               ArticleName = "Träpall",
                               ArticleNumber = 55555,
                               Price = 50
                            },
                            ArticleAmount = 1,
                            RowNumber = 1,
                        }
                    }
                });
        }

    }
}
