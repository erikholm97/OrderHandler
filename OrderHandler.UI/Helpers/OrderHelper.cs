using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Helpers
{
    public static class OrderHelper
    {
        public static int GetOrderRowNumber(int orderId)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var orderRows = db.OrderRows.Select(x => x).Where(x => x.RowNumber == orderId).ToList();

                if(orderRows.Count == 0)
                {
                    return 1;
                }

                return orderRows.Select(x => x.RowNumber).Max();
                

            }
        }
    }
}
