using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Models
{
    public class OrderRowViewModel
    {
        public int OrderId { get; set; }
        public int ArticleAmount { get; set; }
        /// <summary>
        /// Article
        /// </summary>
        public int ArticleNumber { get; set; }
        /// <summary>
        /// Article
        /// </summary>
        public string ArticleName { get; set; }
        /// <summary>
        /// Article
        /// </summary>
        public int Price { get; set; }
    }
}
