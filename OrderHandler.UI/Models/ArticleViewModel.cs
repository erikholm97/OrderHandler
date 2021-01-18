using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Models
{
    public class ArticleViewModel
    {
        public int OrderRowsFound { get; set; }

        public List<OrderRowViewModel> OrderRow { get; set; }

        public long OrderRowSum { get; set; }
    }
}
