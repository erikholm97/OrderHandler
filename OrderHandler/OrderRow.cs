using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderHandler.Data
{
    public class OrderRow
    {
        public int Id { get; set; }
        [Required]
        public int RowNumber { get; set; }
        [Required]
        public int ArticleAmount { get; set; }
        [Required]
        public Article Article { get; set; }
    }
}
