﻿using OrderHandler.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderHandler
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        
    }
}

