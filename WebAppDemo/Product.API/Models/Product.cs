using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{

    public partial class Product 
    {
        public Product() { }
        [Key]
        public int product_id { get; set; }

        public string? product_name { get; set; }

        public int category_id { get; set; }

        public decimal price { get; set; }

        public int? qty { get; set; }

        //public Category? Categories { get; set; }
    }
}