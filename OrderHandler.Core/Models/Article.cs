﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace OrderHandler.Core.Models
{
    public class Article
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ArticleNumber { get; set; }
        [Required]
        public string ArticleName { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
