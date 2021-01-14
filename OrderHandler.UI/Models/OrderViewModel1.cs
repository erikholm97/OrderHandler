using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Models
{
    public class OrderViewModel1
    {
        public int? Id { get; set; }
        public string CustomerName { get; set; }


        public List<OrderRowViewModel> OrderRow { get; set; }

    }
}
