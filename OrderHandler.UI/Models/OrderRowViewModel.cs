using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.UI.Models
{
    public class OrderRowViewModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Du måste ange antalet ordrar.")]
        public int ArticleAmount { get; set; }
        public int ArticleNumber { get; set; }
        [Required(ErrorMessage = "Du måste ange ett namn för angivna artikeln.")]
        public string ArticleName { get; set; }
        [Required(ErrorMessage = "Du måste ange ett pris för den angivna artikeln.")]
        public int Price { get; set; }
        public long OrderSum { get; set; }

        public int OrderRowNr { get; set; }

        public string CustomerName { get; set; }

    }
}
