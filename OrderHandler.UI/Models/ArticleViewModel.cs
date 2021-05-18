using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Models
{
    public class ArticleViewModel
    {
 
        public int Id { get; set; }

        public int ArticleNumber { get; set; }

        public string ArticleName { get; set; }

        public int Price { get; set; }
    }
}
