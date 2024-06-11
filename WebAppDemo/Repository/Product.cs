using System;
using System.Collections.Generic;

namespace Respository
{

    public partial class Product 
    {
        public Product() { }
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int? Qty { get; set; }

        public Category? Category { get; set; }
    }
}